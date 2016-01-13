#pragma once
#include <vector>
using namespace std;

enum TileType {
	Plain = 0,
	Mountain = 1,
	Forest = 2,
	Water = 3
};

enum Race {
	Human = 0,
	Elf = 1,
	Orc = 2
};

class Algo {
public:
	Algo();
	~Algo() {}

	// You can change the return type and the parameters according to your needs.
	void fillMap(TileType map[], int size, int pos[]);
	void getMoves(TileType map[], int nbTiles, int pos[], int curr_pos[], int curr_p, Race race, int moves[]);
};


#define EXPORTCDECL extern "C" __declspec(dllexport)
//
// export all C++ class/methods as friendly C functions to be consumed by external component in a portable way
///

EXPORTCDECL void Algo_getMoves(Algo* algo, TileType map[], int size, int pos[], int curr_pos[], int curr_p, Race race, int moves[]){
	return algo->getMoves(map, size, pos, curr_pos, curr_p, race, moves);
}

EXPORTCDECL void Algo_fillMap(Algo* algo, TileType map[], int size, int pos[]) {
	return algo->fillMap(map, size, pos);
}

EXPORTCDECL Algo* Algo_new() {
	return new Algo();
}

EXPORTCDECL void Algo_delete(Algo* algo) {
	delete algo;
}
