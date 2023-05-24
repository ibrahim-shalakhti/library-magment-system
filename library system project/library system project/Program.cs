using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LMS
{
    public struct User
    {
        public string username { get; set; }
        public int mode { get; set; }
        public string password { get; set; }
        public string phone_number { get; set; } //contact info

        public User(string un, string pw, int m, string phone)
        {
            username = un;
            password = pw;
            mode = m;
            phone_number = phone;
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
    }

    public struct Book
    {
        public string title { get; set; }
        public string author { get; set; }
        public int ISBN { get; set; }
        public string genre { get; set; }
        public int publication_year { get; set; }
        public bool on_loan { get; set; }


        public Book(string t, string a, string g, int I, Boolean o, int p)
        {
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
            Console.WriteLine("Title: " + title + "         |" + "ISBN: " + ISBN);
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
        public int fine;
    }
    public struct Book_return_req
    {
        public User user;
        public Book book;
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

        public static int req_id = 0, books_return_req_id = 0;


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

            log_in();
            add_borrow_req();
            respond_to_borrow_req();
            printBooks();
            return_book_req();
            return_req_approval();
            printBooks();
            print_borrow_req();
            print_return_reqs();


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

                if (book.author.ToLower() == by_title.ToLower())
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
            int i = int.Parse(Console.ReadLine());
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
            System.Console.WriteLine("Please Enter Your User Name...");
            string UN = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Your Password...");
            string PW = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Your Phone Number...");
            string ph = Console.ReadLine() + "";
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
                users.Add(new User(UN, PW, 2, ph));
            }

        }
        public static void add_new_book()
        {
            Console.WriteLine("Adding a new book...");
            Console.WriteLine("Please enter title of new book...");
            string t = Console.ReadLine() + "";
            Console.WriteLine("Please enter author name...");
            string a = Console.ReadLine() + "";
            Console.WriteLine("Please enter ISBN...");
            int i = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter publication year...");
            int p = int.Parse(Console.ReadLine());
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
                }
                else if (!password_found)
                {
                    Console.WriteLine("Incorrect password.");
                }
                else if (logged_in)
                {
                    Console.WriteLine("Welcome " + un + " to our LMS.");
                    Console.WriteLine("______________________________________");
                }
            }
            else if (l == "2") { }
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
            System.Console.WriteLine("Please Enter User Name to add...");
            string UN = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Password...");
            string PW = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter Phone Number...");
            string ph = Console.ReadLine() + "";
            System.Console.WriteLine("Please Enter user mode...");
            System.Console.WriteLine("Please Enter 2 for customer mode...");
            System.Console.WriteLine("Please Enter 1 librarian mode...");
            int m = int.Parse(Console.ReadLine());
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
        }
        public static void serialize_books()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));
            using (FileStream fileStream = new FileStream("books.xml", FileMode.Create))
            {
                serializer.Serialize(fileStream, books);
            }

            Console.WriteLine("Books serialized to XML successfully.");
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
        public static void print_books_ISBN()
        {
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
            BorrowReq req = new BorrowReq();
            print_books_ISBN();
            Console.WriteLine("Please enter the ISBN of the book you want to request.");
            int isbn = int.Parse(Console.ReadLine());
            Book book = books.Find(book => book.ISBN == isbn);
            if (books.Exists(book => book.ISBN == isbn))
            {
                req_id++;
                req.book = book;
                req.user = logged_in_account;
                req.id = req_id;
                borrowRequests.Add(req);
            }
            else
            {
                Console.WriteLine("book not found.");
            }
        }
        public static void print_borrow_req()
        {
            foreach (BorrowReq r in borrowRequests)
            {
                Console.WriteLine("requist_id " + r.id + " | user " + r.user.username + " requists " + r.book.title);

            }
        }
        public static void respond_to_borrow_req()
        {
            print_borrow_req();
            Console.WriteLine("__________________________________________________");
            Console.WriteLine("Please enter the id of the requist you want to respond to....");
            int req_id = int.Parse(Console.ReadLine());
            BorrowReq r = borrowRequests.Find(borrowreq => borrowreq.id == req_id);
            if (borrowRequests.Exists(borrowreq => borrowreq.id == req_id))
            {
                Console.WriteLine("Please enter yes if you approve this requist. and no if you dont approve it.....");
                string s = Console.ReadLine();
                if (s == "yes")
                {
                    Console.WriteLine("Please enter the due date of the book return in the form of how many days can this user have this book.");
                    Console.WriteLine("Please enter the days as integer number.");
                    int days = int.Parse(Console.ReadLine());
                    r.date = days;
                    r.book.on_loan = true;
                    for (int i = 0; i < books.Count; i++)
                    {
                        if (r.book.ISBN == books[i].ISBN)
                        {
                            books[i] = r.book; break;
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine("requist updated.");
                    //to do map user book
                    Loaned_books lb = new Loaned_books();
                    lb.book = r.book;
                    lb.user = r.user;
                    lb.due_date = days;
                    books_on_loan.Add(lb);


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
                Console.WriteLine("requist not found.");
            }

        }

        public static void return_book_req()
        {
            int count = 0;
            foreach (Loaned_books lb in books_on_loan)
            {
                if (lb.user.username == logged_in_account.username)
                {
                    Console.WriteLine("title " + lb.book.title + "   | ISBN" + lb.book.ISBN);
                    count++;
                }
            }
            if (count > 0)
            {
                Console.WriteLine("what book do you want to return?");
                Console.WriteLine("Please enter the ISBN of one of the above books");
                Console.WriteLine("_______________________________________________________");
                int isbn = int.Parse(Console.ReadLine());
                Book_return_req book_Return_Req = new Book_return_req();
                book_Return_Req.user = logged_in_account;
                book_Return_Req.book = books.Find(book => book.ISBN == isbn);
                books_return_req_id++;
                book_Return_Req.id = books_return_req_id;
                Console.WriteLine("request pending librarian approval.");
                books_return_reqs.Add(book_Return_Req);




            }
            else
            {
                Console.WriteLine("you don't have any books to return");
            }
        }
        public static void print_return_reqs()
        {
            foreach (Book_return_req brr in books_return_reqs)
            {
                Console.WriteLine("customer " + brr.user.username + " wants to return book:      =>     " + brr.book.ISBN + "   " + brr.book.title);
            }

        }
        public static void return_req_approval()
        {
            print_return_reqs();
            Console.WriteLine("please enter return request id ....");
            int id = int.Parse(Console.ReadLine());
            Book_return_req brr = books_return_reqs.Find(brr => brr.id == id);
            if (books_return_reqs.Exists(brr => brr.id == id))
            {
                brr.book.on_loan = false;
                int days_taken;
                Console.WriteLine("please enter how many days the book have been taken...");
                days_taken = int.Parse(Console.ReadLine());
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
                    if (brr.book.ISBN == books[i].ISBN)
                    {
                        books[i] = brr.book;
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

    }
    internal class Program
    {

        static void Main(string[] args)
        {
            LDB.init();

            LDB.unit_testing();


        }
    }
}