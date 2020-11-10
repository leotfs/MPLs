namespace MPL.model
{
  class ItemEstoque : ABaseModel
  {
      private int quantidade;
      public int Quantidade
      {
          get { return quantidade; }
          set { quantidade = value; }
      }
      private Produto produto;
      public Produto Produto
      {
          get { return produto; }
          set { produto = value; }
      }
      private string endereco;
      public string Endereco
      {
          get { return endereco; }
          set { endereco = value; }
      }
      
  }
}