using RestWithASPNETUdemy.Model;


namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
         
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for(int i = 0; i < 8; i++)
            {
                Person person = mockPerson(i);
                persons.Add(person);
            }
            return persons;
        }

      

        public Person FindByID(long id)
        {
            return new Person 
            { 
                Id = IncrementAndGet(),
                firstName = "Test",
                lastName = "Test",
                Address = "Orestes Guimaraes",
                Gender  = "Male",
            };
        }

        public Person Update(Person person)
        {
            return person;
        }

        private Person mockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                firstName = "PersonFirstName" +i ,
                lastName = "PersonLastNAme"+ i,
                Address = "Orestes Guimaraes, n "+ i,
                Gender = "Male",
            };
        }

        private long IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
