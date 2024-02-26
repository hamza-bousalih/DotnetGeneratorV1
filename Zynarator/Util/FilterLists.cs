using DotnetGenerator.Zynarator.Bean;

namespace DotnetGenerator.Zynarator.Util;

public static class FilterLists
{
    public static List<List<TEntity>> GetToBeSavedAndToBeDeleted<TEntity>(List<TEntity>? oldList,List<TEntity>? newList)
        where TEntity : IBusinessObject
    {
        List<List<TEntity>> result = new();
        List<TEntity> resultDelete = new();
        List<TEntity> resultUpdateOrSave = new();

        if (oldList == null || !oldList.Any() && newList != null && newList.Any())
        {
            if (newList != null) resultUpdateOrSave.AddRange(newList);
        }
        else if (newList == null || !newList.Any() && oldList.Any())
        {
            resultDelete.AddRange(oldList);
        }
        else if (newList.Any() && oldList.Any())
        {
            foreach (var myOld in oldList)
            {
                var t = newList.FirstOrDefault(e => myOld.Equals(e));
                if (t != null) resultUpdateOrSave.Add(t);
                else resultDelete.Add(myOld);
            }

            foreach (var myNew in newList)
            {
                var t = oldList.FirstOrDefault(e => myNew.Equals(e));
                if (t == null) resultUpdateOrSave.Add(myNew);
            }
        }

        result.Add(resultUpdateOrSave);
        result.Add(resultDelete);
        return result;
    }
}