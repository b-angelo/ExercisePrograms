﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExerciseProgram.Models.ViewModels
{
    public class SubscriberProfileViewModel
    {
        public string SubscriberName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string EmailAddress { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]        
        public int Weight { get; set; }
        public double BodyMassIndex { get; set; }
        public List<WeightHistory> WeightHistory { get; set; }
        public DateTime DateJoined { get; set; }
        public int CurrentProgramId { get; set; }
        public string CurrentWorkoutName { get; set; }
        public string CurrentWorkoutDescription { get; set; }
        public bool IsCurrentProgramCompleted { get; set; }
        public int CurrentWorkoutExerciseCount { get; set; }
        public int WorkoutsCompletedWeek { get; set; }
        public int WorkoutsCompletedMonth { get; set; }
        public int WorkoutCompletedYear { get; set; }
    }

    public class WeightHistory
    {
        public int Id { get; set; }        
        public int WeightInPounds { get; set; }
        public DateTime CreateDate { get; set; }
        public double Bmi { get; set; }
        public string BmiCategory { get; set; }
    }
}
