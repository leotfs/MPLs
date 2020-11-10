namespace MPL.model


{
  abstract class Pessoa : IBaseModel
  {
    //Declaração de métodos get/set
      protected string nome;
      public string Nome
      {
          get { return nome; }
          set { nome = value; }
      }
      
      protected string login;
      public string Login
      {
          get { return login; }
          set { login = value; }
      }
      
      protected string senha;
      public string Senha
      {
          get { return senha; }
          set { senha = value; }
      }
      

  }
}