#include <iostream>
#include <time.h>

using namespace std;

int main()
{
    int a = 0;
    int b = 2;
    int c = 3;
    long iterations = 100000000;
    clock_t start = clock();
    clock_t end;
    float exec_time;

    for (int i = 0; i <= iterations; i++)
        a += b * 2 + c - i;

    end = clock();

    exec_time = (float)(end - start) / CLOCKS_PER_SEC;

    cout << "C++: " << exec_time << " seconds" << endl;
    return 0;
}
