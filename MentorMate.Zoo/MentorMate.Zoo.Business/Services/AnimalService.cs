using AutoMapper;
using FluentValidation;
using MentorMate.Zoo.Business.Models.Results;
using MentorMate.Zoo.Data.Constants;
using MentorMate.Zoo.Data.Repositories;
using MentorMate.Zoo.Domain.Models;
using MentorMate.Zoo.Business.DTOs.AnimalDTOs;
using MentorMate.Zoo.Business.Factories;
using Type = MentorMate.Zoo.Domain.Enums.Type;
using MentorMate.Zoo.Business.Strategy;

namespace MentorMate.Zoo.Business.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly IResultFactory _resultFactory;
        private readonly IFoodStrategy _foodStrategy;
        private readonly IValidator<AnimalValidateDTO> _validator;

        public AnimalService(
            IMapper mapper,
            IAnimalRepository animalRepository,
            IResultFactory resultFactory,
            IValidator<AnimalValidateDTO> validator,
            IFoodStrategy foodStrategy)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
            _resultFactory = resultFactory;
            _validator = validator;
            _foodStrategy = foodStrategy;
        }

        public async Task<IResult<AnimalViewDTO>> GetByIdAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            var animalDoesNotExist = animal == null;

            if (animalDoesNotExist)
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AnimalViewDTO>(AnimalErrorMessages.AnimalNotFound);

                return notFoundResult;
            }

            var animalViewDTO = _mapper.Map<AnimalViewDTO>(animal);

            var herbivoreStatistics = await _animalRepository.GetTypeStatisticsAsync(Type.Herbivore) ?? new AnimalStatistics();
            animalViewDTO.Food = _foodStrategy.Strategy(herbivoreStatistics, animalViewDTO);

            var okResult = _resultFactory.GetOkResult(animalViewDTO);

            return okResult;
        }

        public async Task<IEnumerable<IEnumerable<AnimalResultDTO>>> GetAllAsync()
        {
            var animals = await _animalRepository.GetAllGroupedAndSortedAsync();
            var animalResultDTOs = _mapper.Map<IEnumerable<IEnumerable<AnimalResultDTO>>>(animals);

            return animalResultDTOs;
        }

        public async Task<IResult<AnimalResultDTO>> AddAsync(AnimalAddDTO animalAddDTO)
        {
            var animalValidateDTO = _mapper.Map<AnimalValidateDTO>(animalAddDTO);
            var validation = _validator.Validate(animalValidateDTO);
            var animalIsNotValid = !validation.IsValid;

            if (animalIsNotValid)
            {
                var errorMessages = validation.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AnimalResultDTO>(errorMessages);

                return badRequestResult;
            }

            var animalName = animalAddDTO.Name;
            var animal = await _animalRepository.GetByNameAsync(animalName);
            animal = _mapper.Map(animalAddDTO, animal);

            try
            {
                await _animalRepository.AddAsync(animal);
            }
            catch
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AnimalResultDTO>(AnimalErrorMessages.AnimalCollisionInDatabase);

                return badRequestResult;
            }

            var animalResultDTO = _mapper.Map<AnimalResultDTO>(animal);
            var createdResult = _resultFactory.GetCreatedResult(animalResultDTO);

            return createdResult;
        }

        public async Task<IResult<AnimalResultDTO>> UpdateAsync(int id, AnimalUpdateDTO animalUpdateDTO)
        {
            var animalValidateDTO = _mapper.Map<AnimalValidateDTO>(animalUpdateDTO);
            animalValidateDTO.Id = id;
            var validation = _validator.Validate(animalValidateDTO);
            var animalIsNotValid = !validation.IsValid;

            if (animalIsNotValid)
            {
                var errorMessages = validation.Errors
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                var badRequestResult = _resultFactory.GetBadRequestResult<AnimalResultDTO>(errorMessages);

                return badRequestResult;
            }

            var animalName = animalUpdateDTO.Name;
            var animalByName = await _animalRepository.GetByNameAsync(animalName);
            var animalWithThatNameAlreadyExists = animalByName != null;

            if (animalWithThatNameAlreadyExists)
            {
                var badRequestResult = _resultFactory.GetBadRequestResult<AnimalResultDTO>(AnimalErrorMessages.AnimalCollisionInDatabase);

                return badRequestResult;
            }

            var animal = await _animalRepository.GetByIdAsync(id);
            animal = _mapper.Map(animalUpdateDTO, animal);

            try
            {
                await _animalRepository.UpdateAsync(animal);
            }
            catch
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AnimalResultDTO>(AnimalErrorMessages.AnimalNotFound);

                return notFoundResult;
            }

            var animalResultDTO = _mapper.Map<AnimalResultDTO>(animal);
            var okResult = _resultFactory.GetOkResult(animalResultDTO);

            return okResult;
        }

        public async Task<IResult<AnimalResultDTO>> DeleteAsync(int id)
        {
            var animal = await _animalRepository.GetByIdAsync(id);

            try
            {
                await _animalRepository.DeleteAsync(animal);
            }
            catch
            {
                var notFoundResult = _resultFactory.GetNotFoundResult<AnimalResultDTO>(AnimalErrorMessages.AnimalNotFound);

                return notFoundResult;
            }

            var noContentResult = _resultFactory.GetNoContentResult<AnimalResultDTO>();

            return noContentResult;
        }
    }
}
