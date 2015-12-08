#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 


using namespace std;



void Algo::fillMap(map<int, map<TileType, int>> map, int size)
{
	//TODO : init map tiles with a better algorithm
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			map[i][j] = (TileType)(i % 4);
		}
	}
}