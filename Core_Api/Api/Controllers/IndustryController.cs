using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.BasicModels;
using Api.Persistence.Dtos;
using Api.Persistence.Repositories.IRepository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class IndustryController : BaseApiController
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public IndustryController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        //[HttpGet]
        //public async Task<ActionResult<List<ProductDto>>> GetProducts([FromQuery] ProductSpecParams productParams)
        //{
        //    var spec = new ProductsWithTypesAndBrands(productParams);

        //    var countSpec = new ProductWithFlitersForCountSpecifications(productParams);

        //    var totalItems = await _productRepo.CountAsync(countSpec);

        //    var products = await _productRepo.ListAsync(spec);
        //    var data = _mapper.Map<List<Product>, List<ProductDto>>(products);

        //    return Ok(new Pagination<ProductDto>(productParams.PageIndex, productParams.PageSize, totalItems, data));
        //}



        [HttpGet]
        public   ActionResult<List<CompanyIndustryDto>> GetIndustries()
        {
            var industries = _unitOfWork.Industry.GetAll();
            List<CompanyIndustryDto> temp = new List<CompanyIndustryDto>();

            foreach (var item in industries)
            {
                temp.Add(_mapper.Map<Industry, CompanyIndustryDto>(item));
            }
            
            return temp;
        }
    }
}
