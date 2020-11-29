#include <string>
#include <iostream>
#include "Stack_unit.h"

/* Note, that this class is a singleton. */
class ObjectPool
{
    private:
        static const int max = 6;
        Stack_unit resources = max;
        int _using = 0;
        static ObjectPool* instance;
        ObjectPool() {}
    public:
        /**
         * Static method for accessing class instance.
         * Part of Singleton design pattern.
         *
         * @return ObjectPool instance.
         */
        static ObjectPool* getInstance()
        {
            if (instance == NULL)
            {
                instance = new ObjectPool;
            }
            return instance;
        }
        /**
         * Returns instance of Resource.
         *
         * New resource will be created if all the resources
         * were used at the time of the request.
         *
         * @return Resource instance.
         */
        Artist* getResource()
        {

            if (_using < max) {
                std::cout << "\nReusing existing." << std::endl;
                Artist* resource = resources.pop();
                _using++;
                return resource;
            }
            return nullptr;
                
        }
        /**
         * Return resource back to the pool.
         *
         * The resource must be initialized back to
         * the default settings before someone else
         * attempts to use it.
         *
         * @param object Resource instance.
         * @return void
         */
        void returnResource(Artist* object)
        {
            if (resources.GetCount() < max) {
                object->ResetValues();
                resources.push(object);
                _using--;
            }   
            else
            {
                cout << "\nLimit reached\n";
            }
        }

        int GetPoolCount()
        {
            int count = resources.GetCount();
            return count;
        }


};
ObjectPool* ObjectPool::instance = 0;
int main()
{
    setlocale(LC_ALL, "RUS");
    ifstream fin("data.txt");
    ObjectPool* pool = ObjectPool::getInstance();
    
    while(fin) {
        Artist* one;
        one = pool->getResource();
        one->InputDataRowFromFileTxt(fin);
        one->PrintData();
        pool->returnResource(one);
    }

    Artist* one = new Artist;
    pool->returnResource(one);
    /* Resources will be created. */
    

    fin.close();
    

    /* Resources will be reused.
     * Notice that the value of both resources were reset back to zero.
     */
    cout << endl;
    while (pool->GetPoolCount()) {
        Artist* one;
        
        one = pool->getResource();
        one->PrintData();
    }
    
    cout << endl;
    system("pause");
    return 0;
}