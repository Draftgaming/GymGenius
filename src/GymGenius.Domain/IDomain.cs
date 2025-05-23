﻿using GymGenius.Domain.Abstraction;

namespace GymGenius.Domain
{
    /// <summary>
    /// Represents the core domain functionality, providing access to the GymGenius repository.
    /// </summary>
    public interface IDomain
    {
        public ICoachRepository CoachRepository { get; }

        /// <summary>
        /// Gets the repository instance used for accessing GymGenius data.
        /// </summary>
        IGymGeniusRepository GymGenius { get; }

        IPlanRepository PlanRepository {  get; }

        IExerciseRepository ExerciseRepository { get; }

        IMachinesRepository MachinesRepository { get; }

        IPeopleRepository PeopleRepository { get; }
    }
}
