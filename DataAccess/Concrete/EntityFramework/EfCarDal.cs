﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarcontext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarcontext context= new RentACarcontext())
            {
                var result = from c in context.Cars
                             join b in context.Brands! on c.BrandId equals b.Id
                             join a in context.Colors! on c.ColorId equals a.Id
                             select new CarDetailDto
                             {CarId=c.CarId, BrandName=b.Name, ColorName=a.Name,DailyPrice=c.DailyPrice, ModelYear=c.ModelYear };
                return result.ToList();
                             
            }
        }
    }
}
