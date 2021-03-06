using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using MPL.model;
using MPL.utils;

namespace MPL.repository.impl
{
  public class BaseRepository : IBaseRepository<ABaseModel>
  {
    static DataBaseGod _DATABASE;
    List<ABaseModel> _ListObj;

    public BaseRepository(List<ABaseModel> ListObj ) => this._ListObj = ListObj;

    public async Task<bool> save(ABaseModel obj){
      int index = _ListObj.FindIndex(modelo => modelo.Id == obj.Id);

      if(index > -1) {
        _ListObj[index] = obj;
      }
      else{
        obj.Id = _ListObj.Max( x => x.Id) + 1;
        _ListObj.Add(obj);
      }

      return await FillFileByBd();
    }
    public async Task<bool> delete(ABaseModel obj){
      if(_ListObj.RemoveAll(x => x.Id == obj.Id) > 0)
        return await FillFileByBd();
        
      return true;
    }
    public async Task<bool> delete(int id){
      
      if(_ListObj.RemoveAll(x => x.Id == id) > 0)
        return await FillFileByBd();
        
      return true;
    }
    public async Task<List<ABaseModel>> selectAll(){
      await FillFileByBd();
      return _ListObj;
    }

    public static async void FillBd(){
      bool filledByFile = await FillBdByFile();
      if(!filledByFile) InitializeBd();
    }

    private static async Task<bool> FillFileByBd(){
      if(_DATABASE == null) FillBd();
      string content = await JsonUtil<DataBaseGod>.Serialize(_DATABASE);
      
      return await Fileutils.WriteFile(content, Constraints.Path_BD);
    }

    private static async Task<bool> FillBdByFile(){
      string content = await Fileutils.ReadFile(Constraints.Path_BD);
      _DATABASE = JsonUtil<DataBaseGod>.Deserialize(content);
      return true;
    }

    private static void InitializeBd(){
      _DATABASE = new DataBaseGod();
      _DATABASE.UsuarioConsumidor = new List<UsuarioConsumidor>();
    }

  }

}