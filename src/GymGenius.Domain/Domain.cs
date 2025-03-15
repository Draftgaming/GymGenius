using GymGenius.Domain.Abstraction;

namespace GymGenius.Domain
{
    /// <summary>
    /// Represents the core domain logic for GymGenius, providing access to repository operations.
    /// </summary>
    /// TODO need to add all the repos with interfaces 
    public class Domain(
        ICoachRepository coachRepository,
        IGymGeniusRepository gymGenius) : IDomain
    {
        public ICoachRepository CoachRepository { get; } = coachRepository;

        /// <inheritdoc />
        public IGymGeniusRepository GymGenius { get; } = gymGenius;
    }
}
