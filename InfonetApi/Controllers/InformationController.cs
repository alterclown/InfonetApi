using InfonetApi.Data.Entities;
using InfonetApi.Service.InfoService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfonetApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        private readonly IInformationService _service;

        public InformationController(IInformationService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("GetInformationList")]
        public async Task<IActionResult> GetInformationList()
        {
            try
            {
                var response = await _service.GetInformationList();
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        // GET: Company/Details/5
        [HttpGet]
        [Route("GetInformationById/{InformationId}")]
        public async Task<IActionResult> InformationDetails(int InformationId)
        {
            try
            {
                var response = await _service.GetInformation(InformationId);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpPost]
        [Route("PostInformation")]
        public async Task<IActionResult> CreateInformation(Infonet infonet)
        {

            try
            {
                var response = await _service.CreateInformation(infonet);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpDelete("DeleteById/{id}")]
        public async Task<IActionResult> DeleteInformation(int id)
        {

            try
            {
                var response = await _service.DeleteInformation(id);
                if (response != null)
                {
                    return Ok(response);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPut]
        [Route("PutInformation/{InformationId}")]
        public async Task<IActionResult> UpdateInformation(int InformationId, Infonet infonet)
        {
            try
            {
                var res = await _service.UpdateInformation(InformationId, infonet);
                if (res != null)
                {
                    return Ok(res);
                }
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
