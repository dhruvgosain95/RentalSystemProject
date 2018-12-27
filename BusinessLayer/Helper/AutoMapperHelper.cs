using AutoMapper;
using DataAccessLayer;
using RentalSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Helper
{
    public class AutoMapperHelper : Profile
    {

        public AutoMapperHelper()
        {
            //automapper
            CreateMap<UserLoginModel, UserLogin>();
            CreateMap<UserLogin, UserLoginModel>();

            CreateMap<ProductModel, Product>();
            CreateMap<Product, ProductModel>();

            CreateMap<FeedbackModel, Feedback>();
            CreateMap<Feedback, FeedbackModel>();

        }
    }
}
