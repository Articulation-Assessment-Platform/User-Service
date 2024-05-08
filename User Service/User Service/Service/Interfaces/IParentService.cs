﻿using Microsoft.AspNetCore.Mvc;
using User_Service.Models;

namespace User_Service.Service.Interfaces
{
    public interface IParentService
    {
        Parent Authenticate(string email, string password);
    }
}
