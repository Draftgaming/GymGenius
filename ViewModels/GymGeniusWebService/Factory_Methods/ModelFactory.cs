namespace GymGeniusWebService.Factory_Methods
{
    //lazy methods
    public class ModelFactory
    {
        CoachCreator? coachCreator;
        ExersiceCreator? exersiceCreator;
        MachinesCreator? machinesCreator;
        MusclesCreator? musclesCreator;
        PeopleCreator? peopleCreator;
        PlanCreator? plansCreator;

        public CoachCreator CoachCreator
        {
            get
            {
                if (this.coachCreator == null)
                    this.coachCreator = new CoachCreator();
                return this.coachCreator;
            }
        }
        public ExersiceCreator ExersiceCreator
        {
            get
            {
                if (this.exersiceCreator == null)
                    this.exersiceCreator = new ExersiceCreator();
                return this.exersiceCreator;
            }
        }
        public MachinesCreator MachinesCreator
        {
            get
            {
                if (this.machinesCreator == null)
                    this.machinesCreator = new MachinesCreator();
                return this.machinesCreator;
            }
        }
        public MusclesCreator MusclesCreator
        {
            get
            {
                if (this.musclesCreator == null)
                    this.musclesCreator = new MusclesCreator();
                return this.musclesCreator;
            }
        }
        public PeopleCreator PeopleCreator
        {
            get
            {
                if (this.peopleCreator == null)
                    this.peopleCreator = new PeopleCreator();
                return this.peopleCreator;
            }
        }
        public PlanCreator PlanCreator
        {
            get
            {
                if (this.PlanCreator == null)
                    this.plansCreator = new PlanCreator();
                return this.plansCreator;
            }
        }
    }
}
