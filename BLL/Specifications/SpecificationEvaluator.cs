﻿using System;
using System.Linq;
using CORE.DAL;
using Microsoft.EntityFrameworkCore;


namespace BLL
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            var query = inputQuery;

            //Check if specs are passed
            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }

            //Ordering Opeators
            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }

            if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            //Paging Operators
            if (spec.IsPagingEnabled)
            {
                query = query.Skip(spec.Skip).Take(spec.Take);
            }
           
            query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            
            return query;

        }
    }
}

