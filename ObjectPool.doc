#include <string>
#include <iostream>
#include "Stack_unit.h"


class ObjectPool
{
    private:
        static const int max = 6;
        Stack_unit resources = max;
        int _using = 0;
        static ObjectPool* instance;
        ObjectPool() {}
    public:
        static ObjectPool* getInstance()
        {
            if (instance == NULL)
            {
                instance = new ObjectPool;
            }
            return instance;
        }
      
        Artist* getResource()
        {

            if (_using < max) {
                std::cout << "\nReusing existing." << std::endl;
                Artist* resource = resources.pop();
                _using++;
                return resource;
            }
            cout << "\n\nNo reusable objetcs\n";
            return nullptr;
                
        }
       
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
    fin.close();

    Artist* disturber = new Artist;
    pool->returnResource(disturber);
 
    cout << endl;
    while (pool->GetPoolCount()) {
        Artist* one;
        one = pool->getResource();
        one->PrintData();
    }

    disturber = pool->getResource();
    disturber->PrintData();

    cout << endl;
    system("pause");
    return 0;
}