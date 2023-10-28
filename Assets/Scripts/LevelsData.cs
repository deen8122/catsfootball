using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class LevelsData  {
	private Level[] _levelArray;
	public LevelsData(){
		_levelArray = new Level[46];
		//++++++++++++++++++++++++++++++++++++++++++++
		                               _levelArray [0] = new Level ("rus" , new Enemy[]{ new Enemy("cat1",18f,22f),new Enemy("cat2",17f,20f),new Enemy("cat3",22f,23f)   });
		//++++++++++++++++++++++++++++++++++++++++++++ Россия
		_levelArray [1] = new Level ("rus" , new Enemy[]{ new Enemy("cat1",16f,22f),new Enemy("cat2",17f,20f),new Enemy("cat3",16f,23f)   });
		//++++++++++++++++++++++++++++++++++++++++++++ Эстония
		_levelArray [2] = new Level ("ist" , new Enemy[]{ new Enemy("cat4",19f,19f),new Enemy("cat5",16f,25f),new Enemy("cat6",15f,17f)   });
		//++++++++++++++++++++++++++++++++++++++++++++ Азербайджан
		_levelArray [3] = new Level ("azer" , new Enemy[]{ new Enemy("cat7",19f,18f),new Enemy("cat8",16f,26f),new Enemy("cat9",16f,28f)   });
		//++++++++++++++++++++++++++++++++++++++++++++ Австралия
		_levelArray [4] = new Level ("rf" , new Enemy[]{ new Enemy("cat1",22f,28f),new Enemy("cat4",22f,26f),new Enemy("cat6",22f,23f)   });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [5] = new Level ("rf2" , new Enemy[]{ new Enemy("cat10",19f,18f),new Enemy("cat11",16f,26f),new Enemy("cat12",16f,28f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [6] = new Level ("rf2" , new Enemy[]{ new Enemy("cat13",19f,18f),new Enemy("cat14",16f,16f),new Enemy("cat15",26f,18f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [7] = new Level ("rf" , new Enemy[]{ new Enemy("cat16",16f,18f),new Enemy("cat17",26f,26f),new Enemy("cat18",16f,28f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [8] = new Level ("rf2" , new Enemy[]{ new Enemy("cat1",19f,18f),new Enemy("cat4",16f,16f),new Enemy("cat7",16f,22f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [9] = new Level ("rf" , new Enemy[]{ new Enemy("cat2",19f,18f),new Enemy("cat5",16f,17f),new Enemy("cat8",16f,28f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [10] = new Level ("rf2" , new Enemy[]{ new Enemy("cat3",19f,18f),new Enemy("cat6",16f,26f),new Enemy("cat9",16f,21f)    });







		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++		
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [11] = new Level ("rf1" , new Enemy[]{ new Enemy("cat1",19f,18f),new Enemy("cat11",22f,26f),new Enemy("cat8",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [12] = new Level ("rf2" , new Enemy[]{ new Enemy("cat2",20f,18f),new Enemy("cat12",21f,18f),new Enemy("cat9",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [13] = new Level ("rf" , new Enemy[]{ new Enemy("cat3",21f,18f),new Enemy("cat13",23f,26f),new Enemy("cat10",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [14] = new Level ("rf2" , new Enemy[]{ new Enemy("cat4",22f,18f),new Enemy("cat14",25f,18f),new Enemy("cat11",Random.Range (16f, 21f),Random.Range (16f, 21f))   });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [15] = new Level ("rf" , new Enemy[]{ new Enemy("cat5",23f,18f),new Enemy("cat15",30f,26f),new Enemy("cat12",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [16] = new Level ("rf2" , new Enemy[]{ new Enemy("cat6",24f,18f),new Enemy("cat16",26f,16f),new Enemy("cat13",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [17] = new Level ("rf" , new Enemy[]{ new Enemy("cat7",25f,18f),new Enemy("cat14",27f,19f),new Enemy("cat14",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [18] = new Level ("rf2" , new Enemy[]{ new Enemy("cat8",26f,18f),new Enemy("cat14",28f,26f),new Enemy("cat15",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [19] = new Level ("rf" , new Enemy[]{ new Enemy("cat9",25f,18f),new Enemy("cat14",19f,19f),new Enemy("cat16",Random.Range (16f, 21f),Random.Range (16f, 21f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [20] = new Level ("rf2" , new Enemy[]{ new Enemy("cat10",25f,18f),new Enemy("cat20",16f,26f),new Enemy("cat17",Random.Range (16f, 21f),Random.Range (16f, 21f))    });


		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++		
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [21] = new Level ("rf1" , new Enemy[]{ new Enemy("cat21",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat8",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [22] = new Level ("rf2" , new Enemy[]{ new Enemy("cat22",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat16",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat9",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [23] = new Level ("rf" , new Enemy[]{ new Enemy("cat23",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat17",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat10",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [24] = new Level ("rf2" , new Enemy[]{ new Enemy("cat24",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat18",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat11",Random.Range (20f, 26f),Random.Range (20f, 26f))   });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [25] = new Level ("rf" , new Enemy[]{ new Enemy("cat25",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat19",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat12",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [26] = new Level ("rf2" , new Enemy[]{ new Enemy("cat26",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat16",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat13",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [27] = new Level ("rf" , new Enemy[]{ new Enemy("cat27",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",17f,26f),new Enemy("cat14",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [28] = new Level ("rf2" , new Enemy[]{ new Enemy("cat28",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",18f,26f),new Enemy("cat25",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [29] = new Level ("rf" , new Enemy[]{ new Enemy("cat29",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",Random.Range (18f, 26f),26f),new Enemy("cat16",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [30] = new Level ("rf2" , new Enemy[]{ new Enemy("cat10",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat20",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat17",Random.Range (20f, 26f),Random.Range (20f, 26f))    });



		_levelArray [31] = new Level ("rf1" , new Enemy[]{ new Enemy("cat1",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat11",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat8",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [32] = new Level ("rf2" , new Enemy[]{ new Enemy("cat22",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat12",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat29",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [33] = new Level ("rf" , new Enemy[]{ new Enemy("cat3",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat13",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat10",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [34] = new Level ("rf2" , new Enemy[]{ new Enemy("cat4",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat11",Random.Range (20f, 26f),Random.Range (20f, 26f))   });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [35] = new Level ("rf" , new Enemy[]{ new Enemy("cat25",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat15",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat12",Random.Range (20f, 26f),Random.Range (20f, 26f))    });






		_levelArray [36] = new Level ("rf2" , new Enemy[]{ new Enemy("cat6",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat16",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat23",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [37] = new Level ("rf" , new Enemy[]{ new Enemy("cat27",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",17f,26f),new Enemy("cat14",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [38] = new Level ("rf2" , new Enemy[]{ new Enemy("cat8",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",18f,26f),new Enemy("cat15",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [39] = new Level ("rf" , new Enemy[]{ new Enemy("cat29",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",Random.Range (18f, 26f),26f),new Enemy("cat26",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [40] = new Level ("rf2" , new Enemy[]{ new Enemy("cat10",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat20",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat17",Random.Range (20f, 26f),Random.Range (20f, 26f))    });



		_levelArray [41] = new Level ("rf1" , new Enemy[]{ new Enemy("cat6",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat1",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat21",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat28",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [42] = new Level ("rf2" , new Enemy[]{ new Enemy("cat12",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat22",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat12",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat9",26f,28f)    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [43] = new Level ("rf" , new Enemy[]{ new Enemy("cat13",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat23",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat13",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat20",Random.Range (20f, 26f),Random.Range (20f, 26f))    });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [44] = new Level ("rf2" , new Enemy[]{ new Enemy("cat14",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat4",Random.Range (18f, 26f),Random.Range (20f, 26f)),new Enemy("cat14",Random.Range (20f, 26f),Random.Range (20f, 26f)),new Enemy("cat11",Random.Range (20f, 26f),Random.Range (20f, 26f))   });
		//++++++++++++++++++++++++++++++++++++++++++++
		_levelArray [45] = new Level ("baskortostan" , new Enemy[]{ new Enemy("cat30",29f,28f),new Enemy("cat15",26f,26f),new Enemy("cat12",26f,28f)    });





	}
	public Level GetLevelData(int i ){
		return _levelArray[i];

	}
}


public class Level {
	public int level;
	public string levelName;
	public int enemyCol;
	public Enemy[] enemy;


	public Level(string _levelname , Enemy[] _Enemy){
		this.levelName = _levelname;
		this.enemyCol = _Enemy.Length;
		this.enemy = _Enemy;
	}

}
public class Enemy {
	public string Name;
	public float SpeedForce;
	public float PassForce;
	public Enemy(string _Name,float _SpeedForce,float _PassForce ){
		Name = _Name;
		SpeedForce = _SpeedForce;
		PassForce = _PassForce;
	}
}
