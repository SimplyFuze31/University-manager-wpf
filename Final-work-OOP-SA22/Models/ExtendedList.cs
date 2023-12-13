namespace Final_work_OOP_SA22;

public class ExtendedList<T> : List<T> where T : EducationalInstitution
{
    public void Replace(T item)
    {
        int index = this.FindIndex(n => n.Id == item.Id);

        if (index != -1)
        {
            RemoveAt(index);
            Insert(index, item);
        }
            
    }
}