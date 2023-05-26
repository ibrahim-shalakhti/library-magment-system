
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace LMS
{
    public struct User
    {
        public string username { get; set; }
        public int mode { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; } //contact info
        public int paid_fines { get; set; }
        public int outstanding_fines { get; set; }
        public List<string> notifications = new List<string>();
        public List<string> messeges = new List<string>();

        public User(string un, string pw, int m, string phone)
        {
            paid_fines = 0;
            outstanding_fines = 0;
            username = un;
            password = pw;
            mode = m;
            phone_number = phone;
        }

        public User(string un, string pw, int m, string phone, List<string> n, List<string> mes)
        {
            paid_fines = 0;
            outstanding_fines = 0;
            username = un;
            password = pw;
            mode = m;
            phone_number = phone;
            if (n.Count > 0)
            {
                foreach (string not in n)
                {
                    notifications.Add(not);
                }
            }

            if (mes.Count > 0)
            {
                foreach (string mese in mes)
                {
                    messeges.Add(mese);
                }
            }
        }
        public void printUser()
        {
            Console.WriteLine("username: " + username);
            Console.WriteLine("password: " + password);
            string s = "";
            if (mode == 0)
                s = "admin";
            else if (mode == 1)
                s = "librarian";
            else if (mode == 2)
                s = "patron";
            Console.WriteLine("mode:     " + s);
            Console.WriteLine("Contact:  " + phone_number);
            System.Console.WriteLine("---------------------------------------------------");
        }
        public void print_standing_out_fines()
        {
            if (outstanding_fines > 0)
                Console.WriteLine("You have " + outstanding_fines + " JD outstanding fines that you have to pay.");
            else Console.WriteLine("you don't have fines to pay.");
        }

        public void print_messeges()
        {
            Console.WriteLine("-----------------------------------------------------------");
            if (messeges.Count > 0)
            {
                foreach (string messege in messeges)
                {
                    Console.WriteLine(messege);
                    Console.WriteLine("-----------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("you have no messeges to read");
                Console.WriteLine("_____________________________________________________________________");
            }

        }
        public void print_notifications()
        {
            Console.WriteLine("________________________________________________________________");
            if (notifications.Count > 0)
            {
                foreach (string notification in notifications)
                {
                    Console.WriteLine(notification);
                    Console.WriteLine("____________________________________________________________________________");
                }
            }
            else
            {
                Console.WriteLine("you have no notifications");
                Console.WriteLine("____________________________________________________________________________");
            }
        }

        public void print_fines()
        {

            Console.WriteLine("user " + username);
            Console.WriteLine("paid fines:        " + paid_fines + " JD.");
            Console.WriteLine("outstanding fines: " + outstanding_fines + " JD.");
            Console.WriteLine("____________________________________________________");
        }
    }

    public struct Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int ISBN { get; set; }
        public string genre { get; set; }
        public int publication_year { get; set; }
        public bool on_loan { get; set; }
        public bool on_req { get; set; }

        public Book(string t, string a, string g, int I, Boolean o, int p)
        {
            on_req = false;
            title = t;
            author = a;
            ISBN = I;
            genre = g;
            on_loan = o;
            publication_year = p;
        }
        public void printBook()
        {
            System.Console.WriteLine("Title:             " + title);
            System.Console.WriteLine("Author:            " + author);
            System.Console.WriteLine("ISBN:              " + ISBN);
            System.Console.WriteLine("genre:             " + genre);
            System.Console.WriteLine("publication_year:  " + publication_year);
            if (on_loan)
                System.Console.WriteLine("on_loan:           " + "Yes");
            else System.Console.WriteLine("on_loan:           " + "No");
            System.Console.WriteLine("---------------------------------------------------");
        }
        public void print_title_ISBN()
        {
            Console.WriteLine("Title: " + title + "         |" + "ISBN:      " + ISBN);
            Console.WriteLine("______________________________________________________________");
        }


    }
    public struct BorrowReq
    {
        public User user;
        public Book book;
        public int date;
        public int id { get; set; }


    }
    public struct Loaned_books
    {
        public User user;
        public Book book;
        public int due_date;
    }
    public struct Book_return_req
    {
        public Loaned_books lb;
        public int id;
    }

    public struct LDB
    {
        public static User logged_in_account = new User();
        public static List<User> users = new List<User>();
        public static List<Book> books = new List<Book>();
        public static List<string> current_books_gens = new List<string>();
        public static List<BorrowReq> borrowRequests = new List<BorrowReq>();
        public static List<Loaned_books> books_on_loan = new List<Loaned_books>();
        public static List<Book_return_req> books_return_reqs = new List<Book_return_req>();

        public static int req_id = 0, books_return_req_id = 0, late_fee = 100;


        public static void unit_testing()
        {
            //add_new_user();
            //LDB.printBooks();
            //LDB.printUsers();
            //LDB.printBooks_by_gen();

            //LDB.admin_del_user();
            //LDB.printUsers();

            //LDB.admin_modfy_user();
            //LDB.printUsers();

            //LDB.build_list_of_gens();
            //LDB.printBooks();
            //LDB.print_gens();

            //LDB.library_report();

            //erialize_books();
            //deserialize_books();
            //add_new_book();
            //printBooks();

            //printBooks_by_gen();
            //printBooks_by_a();

            //add_borrow_req();
            //respond_to_borrow_req();
            //print_borrow_req() ;

            //log_in();
            //add_borrow_req();
            //respond_to_borrow_req();
            //printBooks();
            //return_book_req();
            //return_req_approval();
            //printBooks();
            //print_borrow_req();
            //print_return_reqs();
            //pay_fines();


            //deserialize_all();
            //log_in();
            //add_borrow_req();
            //respond_to_borrow_req();
            //printBooks();
            //return_book_req();
            //return_req_approval();
            //printBooks();
            //print_borrow_req();
            //print_return_reqs();
            //pay_fines();
            //serialize_all();


            main_screen();

        }
        public static int exeption()
        {
            int x = 0;
            try
            {
                x = int.Parse(Console.ReadLine());
                return x;
            }
            catch
            {
                Console.WriteLine("invaild input. please enter an intger");
                return exeption();
            }

        }

        public LDB()
        {
        }
        static void init_users()
        {
            users.Add(new User("admin", "admin", 0, "0786906900"));
            users.Add(new User("ibrahim", "ibrahim", 1, "0790714714"));
            users.Add(new User("anas", "anas", 1, "0799999999"));
            users.Add(new User("baha", "baha", 2, "0790415415"));
            users.Add(new User("bayan", "bayan", 2, "0560714714"));
            users.Add(new User("ahmad", "ahmad", 2, "0814714516"));
            users.Add(new User("yousef", "yousef", 2, "0814134516"));
        }
        static void init_books()
        {
            books.Add(new Book("The Ancient Gods", "gabe philps", "History", 1000, false, 2005));
            books.Add(new Book("The Doctor Of the Poor People", "joshwa dickens", "History", 1003, false, 2019));
            books.Add(new Book("The Wise Sage", "phil jonson", "History", 1001, false, 2000));
            books.Add(new Book("Karabidis, Kingdom of magic", "tommas shelby", "History", 1002, false, 2005));
            books.Add(new Book("The Rich, The Poor And the Wizard", "joshwa dickens", "History", 1004, false, 2017));
            books.Add(new Book("Iris And The Beast", "anas j. hamadi", "History", 1005, false, 2023));
            books.Add(new Book("Tales Of the fairy", "tommas shelby", "History", 1006, false, 2014));
            books.Add(new Book("Black Leopard", "joshwa dickens", "Fantasy", 1007, false, 2011));
            books.Add(new Book("The Arabian Knights", "anas j. hamadi", "Fantasy", 1008, false, 2005));
            books.Add(new Book("The Return Of The King", "phil jonson", "Fantasy", 1009, false, 2009));
            books.Add(new Book("The Two Towers", "joshwa dickens", "Fantasy", 1010, false, 2007));
            books.Add(new Book("Crystal Cave", "anas j. hamadi", "Fantasy", 1011, false, 2008));
            books.Add(new Book("Dragon Cry", "phil jonson", "Fantasy", 1012, false, 2007));
            books.Add(new Book("Half Blood Prince", "tommas shelby", "Fantasy", 1013, false, 2008));
            books.Add(new Book("Welcome to Woodmont College", "anas j. hamadi", "Comedy", 10014, false, 2008));
            books.Add(new Book("Start Without Me", "phil jonson", "Comedy", 1015, false, 2005));
            books.Add(new Book("The Worst Assistant", "tommas shelby", "Comedy", 1016, false, 2008));
            books.Add(new Book("Not Funny", "anas j. hamadi", "Comedy", 1017, false, 2007));
            books.Add(new Book("Jokes to Offend Men", "tommas shelby", "Comedy", 1018, false, 2005));
            books.Add(new Book("Dracula", "anas j. hamadi", "Horror", 1019, false, 2007));

        }
        public static void init()
        {
            init_users();
            init_books();
        }
        public static void print_gens()
        {
            foreach (string s in current_books_gens)
            {
                Console.WriteLine(s);
            }
        }
        public static void build_list_of_gens()
        {
            current_books_gens = new List<string>();
            current_books_gens.Add(books[0].genre);
            foreach (Book book in books)
            {
                for (int i = 0; i < current_books_gens.Count; i++)
                {
                    string g = current_books_gens[i];
                    if (current_books_gens.Contains(book.genre))
                    {
                        continue;
                    }
                    else
                    {
                        current_books_gens.Add(book.genre);
                    }
                }
            }
        }
        public static void printBooks()
        {
            System.Console.WriteLine("---------------------------------------------------");
            foreach (Book book in books)
            {
                book.printBook();
            }
        }
        public static void printUsers()
        {
            Console.Clear();
            System.Console.WriteLine("---------------------------------------------------");
            foreach (User user in users)
            {
                user.printUser();
            }

        }
        public static void printBooks_by_gen()
        {
            build_list_of_gens();
            Console.WriteLine("Current genres:");
            print_gens();
            Console.WriteLine("Enter genre:");
            string by_gen = Console.ReadLine() + "";
            System.Console.WriteLine("---------------------------------------------------");
            int count = 0;
            foreach (Book book in books)
            {

                if (book.genre.ToLower() == by_gen.ToLower())
                {
                    book.printBook();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("No Books in this genre yet");
        }
        public static void printBooks_by_title()
        {
            Console.WriteLine("Enter title:");
            string by_title = Console.ReadLine() + "";
            System.Console.WriteLine("---------------------------------------------------");
            int count = 0;
            foreach (Book book in books)
            {

                if (book.title.ToLower() == by_title.ToLower())
                {
                    book.printBook();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("No Books with this title yet...");
            System.Console.WriteLine("---------------------------------------------------");
        }
        public static void printBooks_by_a()
        {
            Console.WriteLine("Enter author:");
            string a = Console.ReadLine() + "";
            System.Console.WriteLine("---------------------------------------------------");
            int count = 0;
            foreach (Book book in books)
            {

                if (book.author.ToLower() == a.ToLower())
                {
                    book.printBook();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("No Books by this author yet...");
            System.Console.WriteLine("---------------------------------------------------");
        }
        public static void printBooks_by_isbn()
        {
            Console.WriteLine("Enter ISBN:");
            int i = exeption();
            System.Console.WriteLine("---------------------------------------------------");
            int count = 0;
            foreach (Book book in books)
            {

                if (book.ISBN == i)
                {
                    book.printBook();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("No Books with this ISBN yet...");
            System.Console.WriteLine("---------------------------------------------------");
        }
        public static void add_new_user()
        {
            Console.Clear();
            System.Console.WriteLine("Please Enter Your User Name...");
            string UN = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Your Password...");
            string PW = Console.ReadLine() + "";
            string phn= Enterphonenumber();
            //while (!isValid)
            //{
            //    Console.WriteLine("The phone number is invalid \n please re enter the phone number ");
            //    isValid = enterphonenumber();
            //    string phn=

            //}                                                                   /////////////////////////////////////////////////////////////////////function needed
            bool pass_conflict = false, user_conflict = false;
            foreach (User user in users)
            {
                if (user.username.ToLower() == UN.ToLower() || PW.ToLower() == user.password.ToLower())
                {
                    if (user.username.ToLower() == UN.ToLower())
                        user_conflict = true;
                    if (user.password.ToLower() == PW.ToLower())
                        pass_conflict = true;
                    if (pass_conflict && user_conflict)
                        break;
                }
            }
            if (user_conflict || pass_conflict)
                Console.WriteLine("Account can't be registered due to the following conflicts:");
            if (user_conflict)
            {
                Console.WriteLine("Username is already registered.");
                Console.WriteLine("---Please choose a different Username.");
            }
            if (pass_conflict)
            {
                Console.WriteLine("Password is already registered for another account.");
                Console.WriteLine("---For extra security, Please choose a different password.");
            }
            if (user_conflict || pass_conflict)
            {
                Console.WriteLine("_________________________________________________________________");
                add_new_user();
            }
            if (!user_conflict && !pass_conflict)
            {
                users.Add(new User(UN, PW, 2, phn));
            }

        }
        public static string Enterphonenumber()
        {
            System.Console.WriteLine("Please Enter Your Phone Number...");
            string num = Console.ReadLine() + "";
            if (num.Length != 10)
            {
                Console.Write("Phone number must be exactly 10 digits \n");
                Enterphonenumber();


            }
            for (int i = 0; i < num.Length; i++)
            {
                if (num[i] < 48 || num[i] > 57)
                {

                    Console.WriteLine("The phone number is invalid \n");
                    Enterphonenumber();


                }
                else
                    continue;

            }
            return num;
        }
        //public static bool PhoneNumberIsValid(string num)
        //{
        //    bool flag = true;
        //    if (num.Length != 10)
        //    {
        //        Console.Write("Phone number must be exactly 10 digits \n");
        //        flag = false;
        //        return flag;
        //    }
        //    for (int i = 0; i < num.Length; i++)
        //    {
        //        if (num[i] < 48 || num[i] > 57)
        //        {

        //            flag = false;
        //            break;

        //        }
        //        else
        //            continue;
        //    }
            
        //    return flag;

        //}

        public static void add_new_book()
        {
            Console.Clear();
            Console.WriteLine("Adding a new book...");
            Console.WriteLine("Please enter title of new book...");
            string t = Console.ReadLine() + "";
            Console.WriteLine("Please enter author name...");
            string a = Console.ReadLine() + "";
            Console.WriteLine("Please enter ISBN...");
            int i = exeption();
            Console.WriteLine("Please enter publication year...");
            int p = exeption();
            Console.WriteLine("Please enter genre...");
            string g = Console.ReadLine() + "";
            Console.WriteLine("_____________________________________________");
            Console.WriteLine("checking if book can be added....................");
            bool bookname_unique = true, bookISBN_unique = true;
            foreach (Book book in books)
            {
                if (book.title == t)
                {
                    bookname_unique = false;
                }
                if (book.ISBN == i)
                {
                    bookISBN_unique = false;
                }
            }
            if (!bookname_unique || !bookISBN_unique)
            {
                Console.WriteLine("book can't be added due to...");
            }
            if (!bookname_unique)
            {
                Console.WriteLine("book is already registered.");
            }
            if (!bookISBN_unique)
            {
                Console.WriteLine("book ISBN is already used.");
            }
            if (bookISBN_unique && bookname_unique)
            {
                books.Add(new Book(t, a, g, i, false, p));
                Console.WriteLine("Book added to the library.");
                build_list_of_gens();
                add_notification_to_patrons(t);
            }
            Console.WriteLine("_______________________________________________");
        }
        public static void log_in()
        {
            Console.WriteLine("To try log in, Please enter 1");
            Console.WriteLine("To return to the main menu, Please enter 2");
            string l = Console.ReadLine() + "";
            if (l == "1")
            {

            Console.Clear();
                Console.WriteLine("Please enter Username...");
                string un = Console.ReadLine() + "";
                Console.WriteLine("Please enter Password...");
                string pw = Console.ReadLine() + "";
                bool logged_in = false;
                bool username_found = false;
                bool password_found = false;
                foreach (User user in users)
                {
                    if (user.username == un)
                    {
                        username_found = true;
                        if (user.password == pw)
                        {
                            password_found = true;
                            logged_in = true;
                            logged_in_account = user;
                            Console.WriteLine("welcome.");
                        }
                        break;
                    }
                }
                if (!username_found || !password_found)
                {
                    Console.WriteLine("We were unable to log you in because of the following problems.");
                }
                if (!username_found)
                {
                    Console.WriteLine("Username is not registered. please register or choose different account");
                    main_screen();
                }
                else if (!password_found)
                {
                    Console.WriteLine("Incorrect password.");
                    main_screen();
                }
                else if (logged_in)
                {
                    Console.WriteLine("Welcome " + un + " to our LMS.");
                    Console.WriteLine("______________________________________");
                }
            }
            else if (l == "2")
            {
                main_screen();
            }
             
            else
            {
                Console.WriteLine("Invalid input, please try again");
                log_in();
            }

        }
        public static void log_out()
        {
            logged_in_account = new User();
            Console.WriteLine("Logged out.");
            Console.WriteLine("______________________________________");
        }
        public static void printBooks_by_gen(string g)
        {
            Console.Clear();
            string by_gen = g;
            System.Console.WriteLine("---------------------------------------------------");
            foreach (Book book in books)
            {

                if (book.genre.ToLower() == by_gen.ToLower())
                {
                    book.printBook();
                }

            }

        }
        public static void library_report()
        {
            Console.Clear();
            Console.WriteLine("__________________________________");
            Console.WriteLine("    Library report generator");
            Console.WriteLine("__________________________________");
            Console.WriteLine("Books on loan...");
            int count = 0;
            foreach (Book book in books)
            {

                if (book.on_loan == true)
                {
                    book.printBook();
                    count++;
                }

            }
            if (count == 0)
                Console.WriteLine("No Books in on loan yet");
            Console.WriteLine("__________________________________");
            int c = books.Count;
            Console.WriteLine("Total number of book: " + Convert.ToString(c));
            Console.WriteLine("__________________________________");
            Console.WriteLine("printing books by genre");
            LDB.build_list_of_gens();
            foreach (string s in current_books_gens)
            {
                Console.WriteLine("genre: " + s);
                Console.WriteLine("_____________________________________________________________________________");
                printBooks_by_gen(s);
            }
            Console.WriteLine("_____________________________________________________________________________");
        }
        public static void admin_adding_user()
        {
            Console.Clear();
            System.Console.WriteLine("Please Enter User Name to add...");
            string UN = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Password...");
            string PW = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Phone Number...");
            string ph = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter user mode...");
            System.Console.WriteLine("Please Enter 2 for customer mode...");
            System.Console.WriteLine("Please Enter 1 librarian mode...");
            int m = exeption();
            bool pass_conflict = false, user_conflict = false;
            foreach (User user in users)
            {
                if (user.username.ToLower() == UN.ToLower() || PW.ToLower() == user.password.ToLower())
                {
                    if (user.username.ToLower() == UN.ToLower())
                        user_conflict = true;
                    if (user.password.ToLower() == PW.ToLower())
                        pass_conflict = true;
                    if (pass_conflict && user_conflict)
                        break;
                }
            }
            if (user_conflict || pass_conflict)
                Console.WriteLine("Account can't be registered due to the following conflicts:");
            if (user_conflict)
            {
                Console.WriteLine("Username is already registered.");
                Console.WriteLine("---Please choose a different Username.");
            }
            if (pass_conflict)
            {
                Console.WriteLine("Password is already registered for another account.");
                Console.WriteLine("---For extra security, Please choose a different password.");
            }
            if (user_conflict || pass_conflict)
            {
                Console.WriteLine("_________________________________________________________________");
                add_new_user();
            }
            if (!user_conflict && !pass_conflict)
            {
                users.Add(new User(UN, PW, m, ph));
            }
        }
        public static void admin_del_user()
        {
            Console.Clear();
            Console.WriteLine("please enter username you want to delete....");
            string un = Console.ReadLine() + "";
            bool un_found = false;
            User toRemove = new User();
            foreach (User user in users)
            {
                if (user.username == un)
                {
                    Console.WriteLine("username found. deleting user...");
                    un_found = true;
                    toRemove = user;
                    break;
                }
            }
            if (!un_found)
            {
                Console.WriteLine("username not found, getting back to main menu.");
            }
            else
            {
                users.Remove(toRemove);
            }

        }
        public static void admin_modfy_user()
        {
            Console.Clear();
            Console.WriteLine("do you want to modify a user?");
            Console.WriteLine("Please enter yes or no....");
            string s = Console.ReadLine() + "";

            if (s == "yes")
            {
                Console.WriteLine("Please enter user name to modify....");
                string un = Console.ReadLine() + "";
                bool un_found = false;
                User toModify = new User();
                foreach (User user in users)
                {
                    if (user.username == un)
                    {
                        Console.WriteLine("Username found. please choose what you want to modify.");
                        un_found = true;
                        toModify = user;
                        break;
                    }
                }
                if (!un_found)
                {
                    Console.WriteLine("Username not found. please try again.");
                    admin_modfy_user();
                }
                Console.WriteLine("Enter 1 to modify username");
                Console.WriteLine("Enter 2 to modify password");
                Console.WriteLine("Enter 3 to modify phone number");
                Console.WriteLine("Enter 4 to modify mode");
                Console.WriteLine("...");
                string um = Console.ReadLine() + "";
                string newValue = "";
                bool can_modfy = true;
                if (um == "1")
                {
                    Console.WriteLine("Please enter the new username...");
                    newValue = Console.ReadLine() + "";
                    foreach (User user in users)
                    {
                        if (user.username == newValue)
                        {
                            Console.WriteLine("can't modify, username is taken");
                            can_modfy = false;
                            break;
                        }

                    }
                    if (can_modfy)
                    {
                        User user = users.Find(user => user.username == un);
                        user.username = newValue;
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].username == un)
                                users[i] = user;
                        }

                    }
                }
                else if (um == "2")
                {
                    Console.WriteLine("Please enter the new password...");
                    newValue = Console.ReadLine() + "";
                    foreach (User user in users)
                    {
                        if (user.password == newValue)
                        {
                            Console.WriteLine("can't modify, password is used by other accounts");
                            can_modfy = false;
                        }

                    }
                    if (can_modfy)
                    {
                        toModify.password = newValue;
                        Console.WriteLine("done");

                        for (int i = 0; i < users.Count; i++)
                        {
                            if (users[i].password == un)
                                users[i] = toModify;
                        }
                    }
                }
                else if (um == "3")
                {
                    Console.WriteLine("Please enter the new phone number...");
                    newValue = Console.ReadLine() + "";
                    toModify.phone_number = newValue;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].username == un)
                            users[i] = toModify;
                    }
                    Console.WriteLine("done");
                }
                else if (um == "4")
                {
                    Console.WriteLine("Modes: 0->admin, 1->librarian, 2-> customer  ");
                    Console.WriteLine("Please enter the new mode...");
                    newValue = Console.ReadLine() + "";
                    toModify.mode = int.Parse(newValue);
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].username == un)
                            users[i] = toModify;
                    }
                    Console.WriteLine("done");
                }
                else
                {
                    Console.WriteLine("wrong choice, please try again");
                    admin_modfy_user();
                }
                Console.WriteLine("___________________________________");

            }
            else
                if (s == "no")
                admin_screen();
            else
            {
                Console.WriteLine("Invalid choice \n");
                admin_modfy_user();
            }

        }
        //start of variables serialization and deserialization
        public static void serialize_books()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream fileStream = new FileStream("books.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, books);
            }
        }
        public static void serialize_users()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (FileStream fileStream = new FileStream("users.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, users);
            }
        }
        public static void serialize_current_books_gens()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            using (FileStream fileStream = new FileStream("current_books_gens.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, current_books_gens);
            }
        }
        public static void serialize_borrowRequests()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<BorrowReq>));
            using (FileStream fileStream = new FileStream("borrowRequests.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, borrowRequests);
            }
        }
        public static void serialize_books_on_loan()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Loaned_books>));
            using (FileStream fileStream = new FileStream("books_on_loan.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, books_on_loan);
            }
        }
        public static void serialize_books_return_reqs()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book_return_req>));
            using (FileStream fileStream = new FileStream("books_return_reqs.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, books_return_reqs);
            }
        }
        public static void serialize_books_return_req_id()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (FileStream fileStream = new FileStream("books_return_req_id.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, books_return_req_id);
            }
        }
        public static void serialize_req_id()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (FileStream fileStream = new FileStream("req_id.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, req_id);
            }
        }
        public static void serialize_all()
        {
            serialize_books();
            serialize_books_on_loan();
            serialize_books_return_reqs();
            serialize_borrowRequests();
            serialize_current_books_gens();
            serialize_users();
            serialize_req_id();
            serialize_books_return_req_id();
        }
        public static void deserialize_books()
        {
            books = new List<Book>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (StreamReader reader = new StreamReader("books.xml"))
            {
                books = (List<Book>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_users()
        {
            users = new List<User>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
            using (StreamReader reader = new StreamReader("users.xml"))
            {
                users = (List<User>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_current_book_gens()
        {
            current_books_gens = new List<string>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<string>));
            using (StreamReader reader = new StreamReader("current_books_gens.xml"))
            {
                current_books_gens = (List<string>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_borrowReqests()
        {
            borrowRequests = new List<BorrowReq>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<BorrowReq>));
            using (StreamReader reader = new StreamReader("borrowRequests.xml"))
            {
                borrowRequests = (List<BorrowReq>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_books_on_loan()
        {
            books_on_loan = new List<Loaned_books>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Loaned_books>));
            using (StreamReader reader = new StreamReader("books_on_loan.xml"))
            {
                books_on_loan = (List<Loaned_books>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_books_return_reqs()
        {
            books_return_reqs = new List<Book_return_req>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book_return_req>));
            using (StreamReader reader = new StreamReader("books_return_reqs.xml"))
            {
                books_return_reqs = (List<Book_return_req>)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_books_return_req_id()
        {
            books_return_req_id = new int();

            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (StreamReader reader = new StreamReader("books_return_req_id.xml"))
            {
                books_return_req_id = (int)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_req_id()
        {
            req_id = new int();

            XmlSerializer serializer = new XmlSerializer(typeof(int));
            using (StreamReader reader = new StreamReader("req_id.xml"))
            {
                req_id = (int)serializer.Deserialize(reader);
            }
        }
        public static void deserialize_all()
        {
            deserialize_books();
            deserialize_books_on_loan();
            deserialize_books_return_reqs();
            deserialize_borrowReqests();
            deserialize_current_book_gens();
            deserialize_users();
            deserialize_books_return_req_id();
            deserialize_req_id();
        }
        //end of serialization functions
        public static void print_books_ISBN()
        {
            Console.Clear();
            Console.WriteLine("List of available book with its ISBN.");
            Console.WriteLine("_______________________________________");

            foreach (Book book in books)
            {
                if (book.on_loan == false)
                {
                    book.print_title_ISBN();
                }
            }
        }
        public static void add_borrow_req()
        {
            Console.Clear();
            BorrowReq req = new BorrowReq();
            print_books_ISBN();
            Console.WriteLine("Please enter the ISBN of the book you want to request.");
            int isbn = exeption();
            Book book = books.Find(book => book.ISBN == isbn);
            if (books.Exists(book => book.ISBN == isbn))
            {
                if (book.on_req == true)
                {
                    Console.WriteLine("cant request this book because another user requested it");
                }
                else
                {

                    req_id++;
                    req.book = book;
                    req.user = logged_in_account;
                    req.id = req_id;
                    req.book.on_req = true;
                    borrowRequests.Add(req);
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (req.book.ISBN == books[i].ISBN)
                        {
                            req.book.on_req = true;
                            books[i] = req.book; break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("book not found.");
            }
        }
        public static void print_borrow_req()
        {
            Console.Clear();
            foreach (BorrowReq r in borrowRequests)
            {
                Console.WriteLine("request_id " + r.id + " | user " + r.user.username + " requests " + r.book.title);

            }
        }
        public static void respond_to_borrow_req()
        {
            Console.Clear();
            print_borrow_req();
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Please enter the id of the request you want to respond to....");
            int req_id = exeption();
            BorrowReq r = borrowRequests.Find(borrowreq => borrowreq.id == req_id);
            if (borrowRequests.Exists(borrowreq => borrowreq.id == req_id))
            {
                Console.WriteLine("Please enter yes if you approve this request. and no if you dont approve it.....");
                string s = Console.ReadLine();
                if (s == "yes")
                {
                    Console.WriteLine("Please enter the due date of the book return in the form of how many days can this user have this book.");
                    Console.WriteLine("Please enter the days as integer number.");
                    int days = exeption();
                    r.date = days;
                    r.book.on_loan = true;
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (r.book.ISBN == books[i].ISBN)
                        {
                            r.book.on_req = false;
                            books[i] = r.book; break;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("request updated.");
                    //to do map user book
                    Loaned_books lb = new Loaned_books();
                    lb.book = r.book;
                    lb.user = r.user;
                    lb.due_date = days;
                    books_on_loan.Add(lb);


                }
                for (int i = 0; i < books.Count; i++)
                {
                    if (r.book.ISBN == books[i].ISBN)
                    {
                        r.book.on_req = false;
                        books[i] = r.book; break;
                    }
                }
                for (int i = 0; i < borrowRequests.Count; i++)
                {
                    if (borrowRequests[i].id == req_id)
                    {
                        borrowRequests[i] = r; break;
                    }
                }
                borrowRequests.Remove(r);
            }
            else
            {
                Console.WriteLine("request not found.");
            }

        }
        public static void return_book_req()
        {
            Console.Clear();
            int count = 0;
            foreach (Loaned_books lb in books_on_loan)
            {
                if (lb.user.username == logged_in_account.username)
                {
                    Console.WriteLine("title " + lb.book.title + "   | ISBN  " + lb.book.ISBN);
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("what book do you want to return?");
                Console.WriteLine("Please enter the ISBN of one of the above books");
                Console.WriteLine("_______________________________________________________");
                int isbn = exeption();
                Book_return_req book_Return_Req = new Book_return_req();
                book_Return_Req.lb = books_on_loan.Find(books_on_loan => books_on_loan.book.ISBN == isbn);
                if (books_on_loan.Exists(books_on_loan => books_on_loan.book.ISBN == isbn) && logged_in_account.username == books_on_loan.Find(books_on_loan => books_on_loan.book.ISBN == isbn).user.username)
                {

                    books_return_req_id++;
                    book_Return_Req.id = books_return_req_id;

                    Console.WriteLine("request pending librarian approval.");
                    books_return_reqs.Add(book_Return_Req);
                }
                else
                {
                    Console.WriteLine("book was not loaned by you.");
                }



            }
            else
            {
                Console.WriteLine("you don't have any books to return");
            }
        }
        public static void print_return_reqs()
        {
            Console.Clear();
            foreach (Book_return_req brr in books_return_reqs)
            {
                Console.WriteLine("ID:" + brr.id + "-  customer " + brr.lb.user.username + " wants to return book:      =>     " + brr.lb.book.ISBN + "   " + brr.lb.book.title);
            }

        }
        public static void return_req_approval()
        {
            Console.Clear();
            print_return_reqs();
            Console.WriteLine("please enter return request id ....");
            int id = exeption();
            Book_return_req brr = books_return_reqs.Find(brr => brr.id == id);
            if (books_return_reqs.Exists(brr => brr.id == id))
            {
                brr.lb.book.on_loan = false;
                int days_taken;
                Console.WriteLine("please enter how many days the book have been taken...");
                days_taken = exeption();
                for (int i = 0; i < books_return_reqs.Count; i++)
                {
                    if (id == books_return_reqs[i].id)
                    {
                        books_return_reqs[i] = brr;
                        break;
                    }
                }
                for (int i = 0; i < books.Count; i++)
                {
                    if (brr.lb.book.ISBN == books[i].ISBN)
                    {
                        brr.lb.book.on_loan = false;
                        add_notification_to_patrons(brr.lb.book.title);
                        books[i] = brr.lb.book;
                    }
                }
                if (days_taken > brr.lb.due_date)
                {
                    brr.lb.user.outstanding_fines += late_fee * (days_taken - brr.lb.due_date);
                    Console.WriteLine("the costumer has returned the book late.");
                    Console.WriteLine(late_fee * (days_taken - brr.lb.due_date) + "  will be add as late fees for the costumer");
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (users[i].username == brr.lb.user.username)
                        {
                            users[i] = brr.lb.user;
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("the costumer has returned the book early.");
                    Console.WriteLine("no fines calculated");
                }
                for (int i = 0; i < books_return_reqs.Count; i++)
                {
                    if (brr.id == books_return_reqs[i].id)
                    {
                        brr = books_return_reqs[i];
                        break;
                    }
                }

                books_return_reqs.Remove(brr);
                Console.WriteLine("book returned");

            }
            else
            {
                Console.WriteLine("invalid request id ");
            }


        }
        public static void pay_fines()
        {
            Console.Clear();
            Console.WriteLine("enter username of the costumer:");
            string username = Console.ReadLine();

            if (users.Exists(users => users.username == username))
            {
                User bill = users.Find(users => users.username == username);
                Console.WriteLine("this costumer has " + bill.outstanding_fines + " JD outstanding fines");
                Console.WriteLine("instert ammount to be paid in numbers:");
                int paid = exeption();
                if (paid <= bill.outstanding_fines && paid > 0)
                {
                    bill.outstanding_fines -= paid;
                    bill.paid_fines += paid;
                    for (int i = 0; i < users.Count; i++)
                    {
                        if (bill.username == users[i].username)
                        {
                            users[i] = bill; break;

                        }
                    }
                    Console.WriteLine("amount paid successfuly");
                }
                else { Console.WriteLine("invaild ammount you have to pay with in the outstanding ammount"); }
            }
            else { Console.WriteLine("costumer not found"); }
        }

        public static void list_books_loaned_by_user()
        {
            Console.Clear();
            foreach (Loaned_books lb in books_on_loan)
            {
                if (lb.user.username == logged_in_account.username)
                {
                    lb.book.printBook();
                }
            }
        }

        public static void send_messege_to_user()
        {
            Console.Clear();
            Console.WriteLine("______________________________________________________________________________________________");
            Console.WriteLine("Please enter the name of the patron you want to sent him messege.");
            string usertosend = Console.ReadLine() + "";
            Console.WriteLine("Please enter the messege.");
            string messege = Console.ReadLine() + "";
            bool usertosend_found = false;
            foreach (User user in users)
            {
                if (user.username == usertosend)
                {
                    usertosend_found = true;
                    if (user.mode == 2)
                    {
                        user.messeges.Add("messege by librarian " + logged_in_account.username + ".\n" + messege);
                        Console.WriteLine("messege sent to user " + usertosend + " .");
                    }
                    else
                    {
                        Console.WriteLine("you can only send messeges to patrons");
                    }
                    break;
                }


            }
            if (!usertosend_found)
            {
                Console.WriteLine("user not found.");
            }
        }

        public static void delete_book()
        {
            Console.Clear();
            Console.WriteLine("please enter book ISBN to delete");
            int book_isbn = exeption();
            bool book_isbn_found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (book_isbn == books[i].ISBN)
                {
                    book_isbn_found = true;
                    if (books[i].on_loan)
                    {
                        Console.WriteLine("can't be deleted because the book is loaned.");

                    }
                    else
                    {
                        books.Remove(books[i]);
                        Console.WriteLine("book deleted.");

                    }
                    break;
                }
            }
            if (book_isbn_found == false)
            {
                Console.WriteLine("book not found ");
                delete_book();
            }
        }

        public static void fines_report()
        {
            Console.Clear();
            Console.WriteLine("fines for patrons");
            Console.WriteLine("_____________________________________________");
            foreach (User user in users)
            {
                if (user.mode == 2)
                {
                    user.print_fines();
                }
            }

        }

        public static void add_notification_to_patrons(string book_name)
        {
            Console.Clear();
            foreach (User user in users)
            {
                if (user.mode == 2)
                {
                    user.notifications.Add("the book " + book_name + " is now available in the library to be loaned.");
                }
            }
        }
        //program screens
        public static void main_screen()
        {
            
            Console.WriteLine("Welcome to our library management system.");
            Console.WriteLine("Please Choose from the menu bellow what you want to do.");
            Console.WriteLine("_________________________________________________________________________");
            Console.WriteLine("Enter 1 to log in.");
            Console.WriteLine("Enter 2 to register.");
            Console.WriteLine("Enter 3 to exit.");
            int choice = exeption();
            switch (choice)
            {
                case 1:
                    try { deserialize_all(); }
                    catch
                    {
                        Console.WriteLine("this is the first time using the program on this device.");
                        Console.WriteLine("please note at least 60 KB is needed to save recovery files.");
                        serialize_all();
                        deserialize_all();

                    }
                    log_in();
                    if (logged_in_account.username != "")
                    {
                        if (logged_in_account.mode == 0)
                        {
                            admin_screen();
                        }
                        else if (logged_in_account.mode == 1)
                        {
                            librarian_screen();
                        }
                        else if (logged_in_account.mode == 2)
                        {
                            patron_screen();
                        }
                    }
                    break;
                case 2:
                    add_new_user();
                    serialize_all();
                    main_screen();
                    break;
                case 3:
                    break;
            }

        }
        public static void patron_screen()
        {
            while (true)
            {
                Console.WriteLine("_____________________________________________________");
                Console.WriteLine("Please enter a choice.");
                Console.WriteLine("1: request borrow book.");
                Console.WriteLine("2: request return book.");
                Console.WriteLine("3: search for books.");
                Console.WriteLine("4: log_out.");
                Console.WriteLine("5: list the books you have loaned.");
                Console.WriteLine("6: print how much fines you have to pay.");
                Console.WriteLine("7: read your messeges.");
                Console.WriteLine("8: read notifications");


                int choice = exeption();
                switch (choice)
                {
                    case 1:
                        add_borrow_req(); serialize_all(); break;
                    case 2: return_book_req(); serialize_all(); break;
                    case 3: search_book_screen(); break;
                    case 4:
                        log_out();
                        serialize_all();
                        main_screen();
                        break;
                    case 5: list_books_loaned_by_user(); break;
                    case 6: logged_in_account.print_standing_out_fines(); break;
                    case 7: logged_in_account.print_messeges(); break;
                    case 8: logged_in_account.print_notifications(); break;



                }


            }

        }
        public static void librarian_screen()
        {
            while (true)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Please enter option.");
                Console.WriteLine("1: respond to borrow requests.");
                Console.WriteLine("2: respond to return requests.");
                Console.WriteLine("3: print borrow requests.");
                Console.WriteLine("4: print return requests.");
                Console.WriteLine("5: paying fines (customer wants to pay fine).");
                Console.WriteLine("6: search books.");
                Console.WriteLine("7: add new book.");
                Console.WriteLine("8: delete a book.");
                Console.WriteLine("9: log_out.");
                Console.WriteLine("10: send messege to a patron.");
                Console.WriteLine("11: generate report on users fines and outstanding payments.");

                int choice = exeption();
                switch (choice)
                {
                    case 1: respond_to_borrow_req(); serialize_all(); break;
                    case 2: return_req_approval(); serialize_all(); break;
                    case 3: print_borrow_req(); serialize_all(); break;
                    case 4: print_return_reqs(); break;
                    case 5: pay_fines(); serialize_all(); break;
                    case 6: search_book_screen(); break;
                    case 7: add_new_book(); serialize_all(); break;
                    case 8: delete_book(); serialize_all(); break;
                    case 9: log_out(); serialize_all(); main_screen(); break;
                    case 10: send_messege_to_user(); serialize_all(); break;
                    case 11: fines_report(); break;


                }
            }
        }

        public static void admin_screen()
        {
            while (true)
            {
                Console.WriteLine("_____________________________________________");
                Console.WriteLine("Please enter option.");
                Console.WriteLine("1: print all users and their information.");
                Console.WriteLine("2: add new user.");
                Console.WriteLine("3: delete user.");
                Console.WriteLine("4: modify user.");
                Console.WriteLine("5: generate report on library.");
                Console.WriteLine("6: generate report on users fines and outstanding payments.");
                Console.WriteLine("7: log_out.");

                int choice = exeption();
                switch (choice)
                {
                    case 1: printUsers(); break;
                    case 2: admin_adding_user(); serialize_all(); break;
                    case 3: admin_del_user(); serialize_all(); break;
                    case 4: admin_modfy_user(); serialize_all(); break;
                    case 5: library_report(); break;
                    case 6: fines_report(); break;
                    case 7: log_out(); serialize_all(); main_screen(); break;



                }
            }
        }

        public static void search_book_screen()
        {
            Console.WriteLine("_____________________________________");
            Console.WriteLine("Please enter how do you want to search for books.");
            Console.WriteLine("1: search by title or name.");
            Console.WriteLine("2: search by ISBN.");
            Console.WriteLine("3: search by author.");
            Console.WriteLine("4: search by genre.");
            int choice = exeption();
            switch (choice)
            {
                case 1: printBooks_by_title(); break;
                case 2: printBooks_by_isbn(); break;
                case 3: printBooks_by_a(); break;
                case 4: printBooks_by_gen(); break;
            }
        }

    }
    internal class Program
    {

        static void Main(string[] args)
        {

            LDB.init();

            //LDB.unit_testing();
            LDB.main_screen();


        }
    }
}