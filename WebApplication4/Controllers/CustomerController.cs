using CustList.Common;
using CustList.Entities.Entities;
using CustList.Entities.Models;
using CustList.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IEntityService<Customer> _customerServices;
        private readonly IEntityService<CustomerPhone> _customerPhoneService;

        public CustomerController(ILogger<CustomerController> logger, IEntityService<Customer> customerServices, IEntityService<CustomerPhone> customerPhoneService)
        {
            _logger = logger;
            _customerServices = customerServices;
            _customerPhoneService = customerPhoneService;
        }

        [HttpGet("[action]/PhoneList/{cId}")]
        public async Task<IActionResult> Get([FromRoute][Required] int cId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Factory.GetResponse<ErrorServerResponse<object>, object>
               (null, 400, false, ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage)).ToArray()));
            }
            try
            {
                var res = (
                await _customerPhoneService.GetAll(x => x.cId == cId
                ));

                return Ok(res);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        Factory.GetResponse<ErrorServerResponse<object>, object>(null, 400, false, new[] { "An unexpected server error happened" }));
            }


        }

        [HttpPost("[action]/Phone")]
        public async Task<IActionResult> Add([FromBody] PhonePostModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(Factory.GetResponse<ErrorServerResponse<object>, object>
               (null, 400, false, ModelState.Values.SelectMany(x => x.Errors.Select(x => x.ErrorMessage)).ToArray()));
            }
            try
            {
                var res = (
                await _customerPhoneService.Any(x=>x.cpPhone.Trim() == model.Phone.ToLower()
                )).Data;

                if (res)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        Factory.GetResponse<ErrorServerResponse<object>, object>(null, 400, false, new[] { "Phone already exists" }));
                }

                var result = await _customerPhoneService.Add(new CustomerPhone {  cId = model.cId, cpPhone = model.Phone } );

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        Factory.GetResponse<ErrorServerResponse<object>, object>(null, 400, false, new[] { "An unexpected server error happened" }));
            }

        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Add([FromBody]Customer customer )
        {


                if(!ModelState.IsValid)
                {
                     return BadRequest(Factory.GetResponse<ErrorServerResponse<object>, object>
                    (null, 400, false, ModelState.Values.SelectMany(x=>x.Errors.Select(x=>x.ErrorMessage)).ToArray() ));


                }
            try
            {
                var res =(
                await _customerServices.Any(x =>
                x.Name1.ToLower() == customer.Name1.ToLower() &&
                x.Name2.ToLower() == customer.Name2.ToLower() &&
                x.LastName1.ToLower() == customer.LastName1.ToLower() &&
                x.LastName2.ToLower() == customer.LastName2.ToLower()
                )).Data;

                if(res)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, 
                        Factory.GetResponse<ErrorServerResponse<object>, object>(null, 400, false, new[] { "Customer Name already exists" }));
                }

                var result = await _customerServices.Add(customer);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                        Factory.GetResponse<ErrorServerResponse<object>, object>(null, 400, false, new[] { "An unexpected server error happened" }));
            }

            
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Post([FromBody] object value)
        {
            var data = await _customerServices.GetAll();
            return Ok(data);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Delete(int id, object collection)
        {
            var data = await _customerServices.Remove(id);
            return Ok(data);
        }


    }
}
