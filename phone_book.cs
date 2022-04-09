namespace PhoneBook
{
    class Program
    {
        static void Main()
        {
            Book.listOptions();
            int userInput;
            while (isValidInput(userInput = getInput()))
            {
                Console.Clear();
                Book.listOptions();
                if (userInput == 1)
                {
                    Book.people.Add( Book.addPerson(getFirstName(),
                        getLastName(),
                        getPhoneNumber(),
                        getMail()) );
                }

                if (userInput == 2)
                    Book.listPersons();
                if (userInput == 3)
                    Book.deletePerson(getQuery());
                if(userInput == 4)
                {
                    Book.updatePerson(getQuery());
                }
                if (userInput == 5)
                     Book.showPerson(getQuery());

            }

        }

        class Person
        {
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string phoneNumber { get; set; }
            public string mail { get; set; }

        }

        class Book
        {
            public static List<Person> people = new List<Person>();

            public static Person addPerson(string firstName, string lastName, string phoneNumber, string mail)
            {
                Person newPerson = new Person();
                newPerson.firstName = firstName;
                newPerson.lastName = lastName;
                newPerson.phoneNumber = phoneNumber;
                newPerson.mail = mail;
                Console.WriteLine($"[+] Person {newPerson.firstName} created.");
                return newPerson;
            }

            public static Person findPerson(string query)
            {
                Console.WriteLine("\n[..] Searching");
                foreach(Person person in people)
                {
                    if(person.firstName == query)
                        return person;
                    if(person.lastName == query)
                        return person;
                    if (person.phoneNumber == query)
                        return person;
                }
                return null;
            }
            public static void showPerson(string query)
            {
                Person person = Book.findPerson(query);
                if (person != null)
                    Console.WriteLine(
                                        $"{person.firstName}  " +
                                        $"{person.lastName}  " +
                                        $"{person.phoneNumber}  " +
                                        $"{person.mail}"
                                        );
                else
                    Console.WriteLine($"[-] Couldn't find any result for {query}");

            }

            public static void updatePerson(string query)
            {
                Person person = findPerson(query);
                if(person != null)
                {
                    Console.WriteLine($"[+] {person.firstName} found");
                    people.Add(
                        addPerson(
                            getFirstName(),
                            getLastName(),
                            getPhoneNumber(),
                            getMail()
                                 )
                              );
                    people.Remove(person);
                }
                else
                    Console.WriteLine($"[-] Couldn't find any result for {query}");
            }



            public static void deletePerson(string query)
            {
                Person person = findPerson(query);
                if(person != null)
                {
                    Console.WriteLine($"[+] Contact {person.firstName} deleted.");
                    people.Remove(person);
                }
                else
                    Console.WriteLine($"[-] Couldn't find any result for {query}");
            }

            public static void listPersons()
            {
                Console.WriteLine("=============== PhoneBook ==============");
                foreach (Person person in people)
                {
                    Console.WriteLine($"{person.firstName}  " +
                        $"{person.lastName}  " +
                        $"{person.phoneNumber}  " +
                        $"{person.mail}");
                }
            }

            public static void listOptions()
            {
                Console.WriteLine(
                                  "1.Add Contact\n" +
                                  "2.List all Contacts\n" +
                                  "3.Delete Contact\n" +
                                  "4.Update Contact's Info\n" +
                                  "5.Find Contact\n"
                                 );
            }

        }

        public static int getInput()
        {
            Console.WriteLine("\nSelect an option: ");
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string getFirstName(){
            Console.WriteLine("First Name: ");
            return Console.ReadLine();
        } 
        public static string getLastName()
        {
            Console.WriteLine("Last Name: ");
            return Console.ReadLine();
        }
        public static string getPhoneNumber()
        {
            Console.WriteLine("Phone Number: ");
            return Console.ReadLine();
        }
        public static string getMail()
        {
            Console.WriteLine("Mail: ");
            return Console.ReadLine();
        }

        public static string getQuery()
        {
            Console.WriteLine("Search by name,phone number..");
            return Console.ReadLine();
        }

        public static bool isValidInput(int input)
        {
            return input switch
            {
                1 => true,
                2 => true,
                3 => true,
                4 => true,
                5 => true,
                _ => false,
            };
        }
    }
}