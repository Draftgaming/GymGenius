using GymGenius.Domain.Abstraction;
using GymGenius.Domain.Repositories;

namespace GymGenius.Domain
{
    /// <summary>
    /// Represents the core domain logic for GymGenius, providing access to repository operations.
    /// </summary>
    /// TODO need to add all the repos with interfaces 
    public class Domain(
        ICoachRepository coachRepository,
        IGymGeniusRepository gymGenius ,
        IPlanRepository planRepository,
        IExerciseRepository exerciseRepository,
        IMachinesRepository machinesRepository,
        IPeopleRepository peopleRepository) : IDomain
       


    {
        public ICoachRepository CoachRepository { get; } = coachRepository;

        /// <inheritdoc />
        public IGymGeniusRepository GymGenius { get; } = gymGenius;

        public IPlanRepository PlanRepository { get; } = planRepository;
        
        public IExerciseRepository ExerciseRepository { get; } = exerciseRepository;

        public IPeopleRepository PeopleRepository { get; } = peopleRepository;
        
        public IMachinesRepository MachinesRepository { get; } = machinesRepository;
    }
}
