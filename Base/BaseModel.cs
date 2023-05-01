using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PvDriver.Base
{
    public class BaseModel<T>
    {
        public StatusEnum Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public bool IsError()
        {
            if (Status == StatusEnum.error)
            {
                return true;
            }
            return false;
        }

        public bool IsEmpty()
        {
            if (Status == StatusEnum.empty)
            {
                return true;
            }
            return false;
        }

        public bool IsOk()
        {
            if (Status == StatusEnum.success)
            {
                return true;
            }
            return false;
        }
    }

    public enum StatusEnum
    {
        success = 1, empty = 2, error = 0
    }
}
