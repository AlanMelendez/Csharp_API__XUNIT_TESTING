using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FakeItEasy;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Controllers;
using PokemonReviewApp.Dto;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;

namespace PokemonApiApp.Tests.Controller
{
    public class PokemonControllerTests 
    {
        private readonly IPokemonRepository _pokemonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public PokemonControllerTests()
        {
            _pokemonRepository = A.Fake<IPokemonRepository>();
            _reviewRepository = A.Fake<IReviewRepository>();
            _mapper = A.Fake<IMapper>();
        }

        [Fact]
        public void GetPokemons_ReturnOk()
        {
            //Arrange
            var pokemons = A.Fake<ICollection<PokemonDto>>();
            var pokemonsList = A.Fake<List<PokemonDto>>();

            A.CallTo(() => _mapper.Map<List<PokemonDto>>(pokemons)).Returns(pokemonsList);

            var controller = new PokemonController(_pokemonRepository, _reviewRepository, _mapper);

            //Act
            var result = controller.GetPokemons();

            //Assert
            result.Should().NotBeNull();
        }

    }
}
