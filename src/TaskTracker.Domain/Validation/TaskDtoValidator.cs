﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Dtos;

namespace TaskTracker.Domain.Validation
{
    public class TaskDtoValidator : AbstractValidator<TaskDto>
    {
        public TaskDtoValidator()
        {
            RuleFor(task => task.Title)
                .NotEmpty().WithMessage("The task name cannot be empty.")
                .MaximumLength(20).WithMessage("The task name cannot exceed 20 characters.");

            RuleFor(task => task.Description)
                .NotEmpty().WithMessage("The task description cannot be empty.");

            RuleFor(task => task.CreationDate)
                .NotEmpty().WithMessage("The task creation date cannot be empty.");

            RuleFor(task => task.UpdateDate)
                .NotEmpty().WithMessage("The task update date cannot be empty.");
        }
    }
}