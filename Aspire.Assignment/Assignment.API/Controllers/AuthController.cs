using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using Assignment.Core;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Assignment.Contracts.Data.Entities;
using Assignment.Contracts.DTO;
using Assignment.Core.Exceptions;
using Assignment.Providers.Handlers.Commands;
using Assignment.Providers.Handlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthController(IMediator mediator, IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _mediator = mediator;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var query = new GetAllUserQuery();
            var response = await _mediator.Send(query); 
            return Ok(response);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(int),(int)HttpStatusCode.Created)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO model){
            try
            {
                var command =new CreateUserCommand(model);
                var response=await _mediator.Send(command);
                return Ok(response);
            }
            catch (InvalidRequestBodyException)
            {
                return BadRequest(new BaseResponseDTO{
                    IsSuccess=false
                });
                }
            }
        
       
        [HttpPost("login")]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> Login([FromBody] UserDTO model)
        {
            try
            {
                var command = new SignInUserByUserNameQuery(model.Username,model.Password);
                var response = await _mediator.Send(command);
                if (response==null){
                    return Unauthorized();
                }
                return Ok(response);
                
            }
            catch (InvalidRequestBodyException ex)
            {
                return BadRequest(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = ex.Errors
                });
            }
        }
        
        [HttpGet("name")]
        //[Route("{name}")]
        [ProducesResponseType(typeof(UserDTO), (int)HttpStatusCode.OK)]
        [ProducesErrorResponseType(typeof(BaseResponseDTO))]
        public async Task<IActionResult> GetById(string name)
        {
            try
            {
                var query = new GetUserByUserNameQuery(name);
                var response = await _mediator.Send(query);
                return Ok(response);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(new BaseResponseDTO
                {
                    IsSuccess = false,
                    Errors = new string[] { ex.Message }
                });
            }
        }
    }
}

 