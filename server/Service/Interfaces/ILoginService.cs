﻿using Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ILoginService:IService<UserDetailesDto>
    {
        public UserDetailesDto Login(string email, string password);
    }
}
