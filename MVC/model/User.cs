class User
{
    string name;
    string email;
    string password;
    int userID = 1;

    public User (){
        this.name = "First user";
        this.email= "levi.vinicius@outlook.com";
        this.password = "123456";
        this.userID = 1;
    }

    public User(string name, string email, string password){
        this.name = name;
        this.email = email;
        this.password = password;
        this.userID++;
    }

    private void setName(string name){
        this.name = name;
    }

    public string getName(){
        return this.name;
    }

    private void setEmail(string email){
        this.email = email;
    }

    public string getEmail(){
        return this.email;
    }

    private void setPassword(string password){
        this.password = password;
    }

    public int getUserID(){
        return this.getUserID();
    }
}