using Lab_10;
using System.Xml.Linq;
using Lab_OOP_12;

namespace EventBinaryTree
{
    [Serializable]
    public class BinaryTreeEvent<T> : BinarySearchTree<Organization>
        where T : IComparable, ICloneable
    {
        [field: NonSerialized]
        public event EventHandler<CollectionHandlerEventArgs>? CollectionChange;

        public BinaryTreeEvent() : base(new CustomComparer()) {}

        public BinaryTreeEvent(BinaryTreeEvent<Organization> tree) : base(tree) { }
    
        public virtual void OnCollectionChanged(object source, CollectionHandlerEventArgs e)
        {
            CollectionChange?.Invoke(source, e);
        }

        public override void Add(Organization Organization)
        {
            if (base.Contains(Organization))
                throw new Exception("Ошибка! Такой элемент уже есть");
            base.Add(Organization);
            OnCollectionChanged(this, new CollectionHandlerEventArgs("Added", Organization));
        }

        public override void AddRange(IEnumerable<Organization> collection)
        {
            foreach (var value in collection)
                Add(value);
        }

        public override bool Remove(Organization data)
        {
            if (!base.Contains(data))
                throw new Exception("Ошибка! Этого элемента не существует");
            var result = base.Remove(data);
            OnCollectionChanged(this, new CollectionHandlerEventArgs("Removed", base.Find(data)));
            return result;

        }

        public override void Clear()
        {
            base.Clear();
            OnCollectionChanged(this, new CollectionHandlerEventArgs("Clear", null));
        }

        public bool Mod(Organization Organization)
        {
            var findItem = base.Find(Organization);
            if (findItem != null)
            {
                findItem.Name = Organization.Name;
                findItem.Address = Organization.Address;
                findItem.NumEmployess = Organization.NumEmployess;
                OnCollectionChanged(this, new CollectionHandlerEventArgs("changed", Organization));
                return true;
            }
            throw new ArgumentException("Такой организации нет");
        }
        public void CreateRandomTree(int size)
        {
            AddRange(GenerateRandomOrganizationArray(size, new CustomComparer()));
        }
        public static Organization[] GenerateRandomOrganizationArray(int size, CustomComparer comparer)
        {
            Random rnd = new();
            Organization[] Organization = new Organization[size];
            for (int i = 0; i < size; i++)
            {
                int item = rnd.Next(1, 6);
                Organization[i] = CreateOrganization(item);
                Organization[i].RandomInit();
                for (int j = 0; j < i; j++)
                    if (comparer.Compare(Organization[i], Organization[j]) == 0)
                        i--;
            }
            return Organization;
        }
        public static Organization CreateOrganization(int itemType)
        {
            return itemType switch
            {
                1 => new Organization(),
                2 => new Factory(),
                3 => new Library(),
                4 => new InsuranceCompany(),
                5 => new ShipBuildingCompany(),
                _ => throw new ArgumentException("Неизвестный тип!"),
            };
        }
        private static string GetTextIEnumerable(IEnumerable<Organization> lst, string row = "", string Empty = "Пусто")
        {
            var result = row;
            foreach (var item in lst)
                result += item.ToString() + "\n";
            return result == row ? Empty : result;
        }
        public static string GetTextSortTree(BinaryTreeEvent<Organization> tree)
        {
            var result = GetTextIEnumerable(tree, "\tОтсортированное дерево:\n", "Дерево пустое");
            return result;
        }
        public static string GetTextFilter(BinaryTreeEvent<Organization> tree, Type type)
        {
            var lst = FilterOrganizations(tree, type);

            var result = GetTextIEnumerable(lst, "\tOrganizations:\n", "not.");

            return result;

        }
        public static IEnumerable<Organization> FilterOrganizations(BinaryTreeEvent<Organization> tree, Type type)
        {
            // Фильтрация элементов по заданному типу и значению поля
            return tree.Where(obj =>
            {
                // Проверка типа объекта
                return (obj.GetType() == type);
            });
        }
    }
}