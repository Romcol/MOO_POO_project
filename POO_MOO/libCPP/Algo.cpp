#include "Algo.h"
#include <iostream>
#include <algorithm>
#include <time.h>
#include <math.h> 


using namespace std;

Algo::Algo() {}

void Algo::fillMap(TileType map[], int size, int pos[])
{
	vector<TileType> tileInit;
	int count;
	int r;
	srand(time(NULL));

	count = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			tileInit.push_back((TileType)(count % 4));
			count++;
		}
	}

	count = 0;
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			r = rand() % tileInit.size();
			map[count] = tileInit[r];
			tileInit.erase(tileInit.begin() + r);
			count++;
		}
	}

	r = rand() % 1 + 1;
	int a = rand() % 1;
	if (a == 0)
	{
		pos[0] = r;
		pos[size*size - 1] = (r == 1) ? 2 : 1;
	}
	else {
		pos[size-1] = r;
		pos[size*size-size] = (r == 1) ? 2 : 1;
	}
}

int getIndexMax(int a[])
{
	int max = a[0];
	int maxind = 0;
	for (int i = 1; i < sizeof(a);i++)
	{
		if (a[i] > max)
		{
			max = a[i];
			maxind = i;
		}
	}
	return maxind;
}
void Algo::getMoves(TileType map[], int nbTiles, int pos[], int curr_pos[], int curr_p, Race race, int moves[])
{
	/*
	Notation positions
		1
		5
	0 4 X 6 2
		7
		3
	*/
	int check[4] = {-2,-1,1,2};
	int size = nbTiles*nbTiles;
	int notation[8] = { 0,4,6,2,1,5,7,3 };
	int invnotationx[8] = { -2, 0, 2, 0, -1, 0, 1, 0 };
	int invnotationy[8] = { 0, -2, 0, 2, 0, -1, 0, 1 };
	int posworks[8];

	int v = 0;
	int otherplayer = (curr_p == 1) ? 2 : 1;

	
	for (int i = 0; i < 4; i++)
	{
		if (((curr_pos[0] + check[i]) + (curr_pos[1])*nbTiles) > 0 && pos[(curr_pos[0] + check[i]) + (curr_pos[1])*nbTiles] != otherplayer)
		{
			posworks[notation[v]] = (curr_pos[0] + check[i]) + (curr_pos[1])*nbTiles;
		}
		else {
			posworks[notation[v]] = -1;
		}
		v++;
	}
	
	for (int i = 0; i < 4; i++)
	{
		if (((curr_pos[0]) + (curr_pos[1] + check[i])*nbTiles) > 0 && pos[(curr_pos[0]) + (curr_pos[1] + check[i])*nbTiles] != otherplayer)
		{
			posworks[notation[v]] = (curr_pos[0]) + (curr_pos[1] + check[i])*nbTiles;
		}
		else {
			posworks[notation[v]] = -1;
		}
		v++;
	}

	int score[8];
	for (int i = 0; i < 8; i++)
	{
		int j = posworks[i];
		if (j != -1)
		{
			switch (race)
			{
			case Human:
				switch (map[j])
				{
				case Plain:
					score[i] = 3;
					break;
				case Mountain:
					score[i] = 2;
					break;
				case Forest:
					score[i] = 2;
				case Water:
					score[i] = 1;
					break;
				default:
					score[i] = 0;
				}
				break;
			case Elf:
				switch (map[j])
				{
				case Plain:
					score[i] = 1;
					break;
				case Mountain:
					score[i] = 1;
					break;
				case Forest:
					score[i] = 2;
				case Water:
					score[i] = 1;
					if (i >= 4) score[i - 4] = 0;
					break;
				default:
					score[i] = 0;
				}
				break;
			case Orc:
				switch (map[j])
				{
				case Plain:
					score[i] = 1;
					break;
				case Mountain:
					score[i] = 1;
					break;
				case Forest:
					score[i] = 2;
				case Water:
					score[i] = 0;
					if (i >= 4) score[i - 4] = 0;
					break;
				default:
					score[i] = 0;
				}
				break;
			default:
				score[i] = 0;
			}
		}
		else {
			score[i] = -1;
		}
	}
	for (int i = 0; i < 8; i++)
	{
		moves[i] = score[i];
	}
	
	int ind;
	for (int i = 0; i < 3; i++)
	{
		ind = getIndexMax(score);
		score[ind] = 0;
		moves[(curr_pos[0]+invnotationx[ind]) + (curr_pos[1]+invnotationy[ind]) * nbTiles] = 1;
	}
}