﻿using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId =1,BrandId=1,ColorId=1,ModelYear=2020,DailyPrice=20,Description="Max 15 days rental"},
                new Car{CarId =2,BrandId=1,ColorId=2,ModelYear=2018,DailyPrice=14,Description="Max 15 days rental"},
                new Car{CarId =3,BrandId=2,ColorId=2,ModelYear=2021,DailyPrice=18,Description="Max 15 days rental"},
                new Car{CarId =4,BrandId=2,ColorId=1,ModelYear=2014,DailyPrice=10,Description="Max 15 days rental"}

            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car? carToDelete = _cars.FirstOrDefault(c=> c.CarId==car.CarId);
            _cars.Remove(carToDelete!);

        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetByBrandId(int brandId)
        {
            return _cars.Where(c=> c.BrandId==brandId).ToList();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car? carToUpdate = _cars.SingleOrDefault(c=> c.CarId==car.CarId);
            carToUpdate!.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
        }
    }
}
