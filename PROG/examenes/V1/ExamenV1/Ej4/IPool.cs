namespace Ej4
{
    public interface IPool<T>
    {
        int Count { get; }

        T[] ToArray();
        void Release(T element);
        T Acquire();

        IPool<T> Clone();

    }
}
