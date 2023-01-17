﻿using AutoMapper;
using BLL.Services.School.Queries;
using CORE.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mapper
{
    public class Mapping :Profile
    {
        public Mapping()
        {
            CreateMap<School, SchoolDTO>().ReverseMap();
        }
        
    }
}