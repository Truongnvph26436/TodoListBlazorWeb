﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoList.Model.Enums;

namespace TodoList.Model
{
    public class TaskCreateRequest
    {
        // public Guid Id { get; set; } hơi thừa

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        public Priority Priority { get; set; }

    }
}
