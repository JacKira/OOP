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
        //Статический метод для получения единого экземпляра класса
        static ObjectPool* getInstance()
        {
            if (instance == NULL)
            {
                instance = new ObjectPool;
            }
            return instance;
        }
      
        //Метод, которые выдает объект из пула, если есть свободный
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
       
        //Метод вовзрата объекта в пул
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

        //Метод получения количества свободных объектов пуле
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
    ifstream fin("data.txt", ios::in);
    ObjectPool* pool = ObjectPool::getInstance(); //Получаем единственный на всю программу экзмепляр пула
    
    while(fin) {
        Artist* one;
        one = pool->getResource(); //Получаем объект из пула
        one->InputDataRowFromFileTxt(fin); //Записываем данные в объект
        one->PrintData(); //Печатаем результат
        pool->returnResource(one); //Возваращаем объект обратно в пул
    }
    fin.close();

    //Симулируем нарушение работы пула, пытаясь вернуть лишний объект
    Artist* disturber = new Artist;
    pool->returnResource(disturber); //Здесь нам сообщат об ошибки и объект не добавится
 
    //Покажем, что все получаемые объекты изначально пусты
    cout << endl;
    while (pool->GetPoolCount()) {
        Artist* one;
        one = pool->getResource();
        one->PrintData();
    }

    //Симулируем нарушение работы пула, попыткой получить объект из пустого пула
    disturber = pool->getResource();
    disturber->PrintData();

    cout << endl;
    system("pause");
    return 0;
}