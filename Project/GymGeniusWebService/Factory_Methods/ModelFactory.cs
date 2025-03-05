using GymGeniusWebService.DB;
using GymGeniusWebService.Repository;
using System.ComponentModel;

namespace GymGeniusWebService.Factory_Methods
{
    //lazy methods
    //Create an object 
    public class ModelFactory
    {
        CoachCreator? coachCreator;
        ExersiceCreator? exersiceCreator;
        MachinesCreator? machinesCreator;
        MusclesCreator? musclesCreator;
        PeopleCreator? peopleCreator;
        PlanCreator? planCreator;
        DBContext dbContext;

        static ModelFactory instance;

        public static ModelFactory getInstance()
        {
            if (instance == null)
                instance = new ModelFactory();
            return instance;
        }
        private ModelFactory()
        {
            dbContext = DBContext.GetInstance();
        }

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
                return this.PeopleCreator;
            }
        }
        public PlanCreator plansCreator
        {
            get
            {
                if (this.planCreator == null)
                    this.planCreator = new PlanCreator();
                return this.planCreator;
            }
        }

        public static implicit operator ModelFactory(GymGeniusUnitofWork v)
        {
            throw new NotImplementedException();
        }
    }
}
