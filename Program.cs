using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


//Para este programa, considerei Sul e Sudeste com dois sensores, apenas para efeito de análise.
//Norte e Nordeste terão apenas um, por isso apenas contam a quantidade de eventos
// No editor que usei, MonoBehaviour é a classe que possui funções básicos como imprimir mensagem
// por isso, utilizei a classe Radix como filha da classe Monobehaviour
public class Radix : MonoBehaviour {
	//Declaração de objetos  
	Brasil objeto;
	Sudeste objeto1;   
	Sul objeto2;
	Norte objeto3;
    Nordeste objeto4;
    //Uso da coleção dicionário que armazena as regiões e o horário de registro de cada caso
	public Dictionary<string,int> tabeladecasos =  new Dictionary<string, int> ();
	public int numcasos;
	public int[] horariocasos = new int[3];
//vetor que recebe o horário [hh, min, seg]


	int Start ()
		{
//Função principal
//Criação dos objetos   
		objeto = new Brasil ();
		objeto1 = new Sudeste ();
		objeto2 = new Sul ();
		objeto3 = new Norte ();
		objeto4 = new Nordeste ();
		//Este laço verifica se cada função booleana feita nas classes é verdadeira
		//Caso verdadeira, significa que o sensor da região do objeto verificou um evento 
		//os ifs internos são escritos para o caso da existência de dois registros ao mesmo tempo. 
		//O programa deve ser capaz de verificar isso 
		if(objeto1.verificadorSudeste = true || objeto2.verificadorSul = true || objeto3.verificadorNorte = true  || objeto4.verificadorNordeste = true){
			if(objeto1.verificadorSudeste=true)
			{
				horariocasos = objeto.evento;
				numcasos++;
				tabeladecasos.Add("Sudeste", horariocasos);
			}
			if(objeto2.verificadorSul=true)
			{
				horariocasos = objeto.evento;
				numcasos++;
				tabeladecasos.Add("Sul", horariocasos);
			}
			if(objeto3.verificadorNorte=true)
			{
				horariocasos = objeto.evento;
				numcasos++;
				tabeladecasos.Add("Norte", horariocasos);
			}
			if(objeto4.verificadorNordeste=true)
			{
				horariocasos = objeto.evento;
				numcasos++;
				tabeladecasos.Add("Nordeste", horariocasos);
			}
			}
		print(tabeladecasos);
		print(numcasos);
;
	}

    /*GERAR GRÁFICOS!
	chart1.Series["SeriesName"].Points.AddXY(t1, y1);
	O próprio visual studio possui uma funcionalidade que permite gerar gráficos 2D. A coleção Dictionary com os valores adquiridos
	Representa tanto os valores de x quanto de y. Na Coordenada Y temos o número de casos, também descrito com os nomes das regiões.
	Ex: Dicionário        Nordeste 20:13:32
	                      Nordeste 21:00:00
						  Sudeste  22:31:09
 o número de casos também foi contado no laço, o que permite plotar o número pelos horários(keys que recebem um vetor com o 
 horário )  ou as regiões em função do horário. 

 A tabela de casos possui todos os dados necessários para fazer o gráfico 


	*/
		void Update() {
		}
}


class Brasil : MonoBehaviour{

	    /	    //Atributos


		//variáveis globais públicas/Atributos

	public long totalSegundos;
	public long totalMilissegundos;
	public long segundoAtual;
	public long totalMinutos;
	public long minutoAtual;
	public long totalHora;
	public long horaAtual;
	public int[] timestamp = new int[3];
	public string tag;
	public string valor;


		// método que retorna um vetor com horário 


	public int evento()
			{                                            
		
		//Marco zero do sistema operacional Unix
        /*
        Essa estrutura e horário, conheço em Java, mas acredito que exista uma similar em C#
        utilizei uma função que encontrei na internet


       Em java seria 

                long totalMilisegundos = System.currentTimeMillis();
        //-10800000 para passar ao horário brasileiro.
        // pesquisar sistema UNIX
        //Marco zero do sistema operacional UNIX
        // quantidade de milisegundos que se passaram de 1970, à meia-noite
        long totalSegundos = totalMilisegundos/1000;
        long segundoAtual = totalSegundos % 60;
        //segundos atuais
        
        long totalMinutos = totalSegundos/60;
        long minutoAtual = totalMinutos % 60;
        
        long totalHora = totalMinutos/60;
        long horaAtual = totalHora %40;
        
        System.out.println("Horário:" +horaAtual+ ":" +minutoAtual+ ":" +segundoAtual );
        //base horario de Londres 
       

        */
				//segundos atuais
		        totalMilissegundos = (long)(date - new DateTime(1970, 1, 1)).TotalMilliseconds 
		    //Milissegundos passados desde 1970
			    totalSegundos = totalMilissegundos/1000;
		        segundoAtual =  totalSegundos%60

				totalMinutos = totalSegundos/60;
				minutoAtual = totalMinutos % 60;

				totalHora = totalMinutos/60;
				horaAtual = totalHora%40;

				int[] timestamp =  {horaAtual, minutoAtual, segundoAtual};

				string tag = "Brasil";

				string valor = "Dado";
		return timestamp;
	}
}

			//"timestamp": <Unix Timestamp ex: 1539112021301>,
		//"tag": "<string separada por '.' ex: brasil.sudeste.sensor01 >",
		//"valor" : "<string>"
        // Classes filhas são as regiões


class Sudeste : Brasil
     //classe Sudeste filha da classe Brasil 
     
{ 
 enum STT1 {Registra, Nointerruption}   
 //com o enum, é possível criar dois estados, 0 e 1. Quando o estado é 0, registra uma ocorrÊncia
 //Foi utilizado para verificar o estado do Sensor 

	public int sensor1Sudeste; 
	public int sensor2Sudeste;
	//A biblioteca List permite armazenarmos uma variável, possível para depois construirmos uma tabela em SQL por exemplo
	List<int> ListadeEventosSudeste = new List<int>();
	List<int> ListadeHorariosSudeste = new List<int>();
	//Estados possíveis do sensor
	STT1 sensor1A = STT1.Registra;
	STT1 sensor1B = STT1.Nointerruption;
	STT1 sensor2A = STT1.Registra;
	STT1 sensor2B = STT1.Nointerruption;
	int estSensor1;
	int estSensor2;
//Verifica o estado do sensor 

	public bool verificadorSudeste(){
	
		bool ver1;
		if(estSensor1 = (int)sensor1A || estSensor2 = (int)sensor2A)
		{
			ver1 = true;
		}else{
			ver1 = false;
		}
		return ver1;
	}

    //algum sensor no Sudeste verificou ocorrência? Retorna o registro dela


public void funcaodosudeste ()
	{
		// base = permite herdar atributo da classe pai 
	int[] horariosudeste = new int[3];

	int numSudeste = 0;


		if(estSensor1 = (int)sensor1A ) //sensor registrou evento  
		{
			numSudeste++;
			print ("Horario do registro(timestamp) de numero" + numSudeste + "do Sensor 1:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			horariosudeste = {horaAtual, minutoAtual, segundoAtual};  
			for (int i = 0; i < numSudeste; ++i) {
				ListadeEventosSudeste.Add (numSudeste);
				ListadeHorariosSudeste.Add (horariosudeste);

			}

			//guardar valor de casos

		}

		print("Quantidade de registros do sensor 1 para a Regiao Sudeste:"+numSudeste);
		int temporario = numSudeste; 		int temporario = numSudeste; //guarda os dados do registro 1

		numSudeste = 0;
		//guardar valor de casos 

		if(estSensor2 = (int)sensor2A )
		{
			numSudeste++;
			print("Horario do registro(timestamp)  de numero" + numSudeste+ "do Sensor 2:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			for (int j = 0; j < numSudeste; ++j) {
				ListadeEventosSudeste.Add (numSudeste + temporario);
				ListadeHorariosSudeste.Add(horariosudeste);
		//guardar valor de casos
			}
		}

		print("Quantidade de registros do sensor 2 para a Regiao Sudeste:"+numSudeste);
		numSudeste = temporario + numSudeste;

		print("Total de registros dos sensores da regiao Sudeste:" +numSudeste);

		for(int y = 0; y < numSudeste; ++y){
			print(ListadeEventosSudeste[y]);
			print(ListadeHorariosSudeste[y]);
		}//laço que armazena eventos 

}
	public Sudeste()
	{
		this.sensor1Sudeste;
		this.sensor2Sudeste;//  para a classe principal do programa ter acesso a essa variável utilizando o objeto
	}
}




class Sul : Brasil
{
	List<int> ListadeEventosSul = new List<int>();
	List<int> ListadeHorariosSul = new List<int>();
	public int sensor1Sul;
	public int sensor2Sul;
	enum STT2 {Registra, Nointerruption}
	int estSensor1;
	int estSensor2;
    STT2 sensor1A = STT2.Registra;
    STT2 sensor1B = STT2.Nointerruption;
	STT2 sensor2A = STT2.Registra;
	STT2 sensor2B = STT2.Nointerruption;


	public bool verificadorSul(){
		bool ver2;
		if(estSensor1 = (int)sensor1A || estSensor2 = (int)sensor2A)
		{
			ver2 = true;
		}else{
			ver2 = false;
		}
		return ver2;
	}



	public void funcaodosul ()
    
	{
		base.segundoAtual;
		base.minutoAtual;
		base.horaAtual;

		int[] horarioSul = new int[3];
		int numSul = 0;


		if(estSensor1 = (int)sensor1A )
		{
			numSul++;
			print ("Horario do registro(time stamp) numero " + numSul + "do Sensor 1 na Regiao Sul:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			horarioSul = {horaAtual, minutoAtual, segundoAtual};
			for (int i = 0; i < numSul; ++i) {
				ListadeEventosSul.Add (numSul);
				ListadeHorariosSul.Add (horarioSul);

			}
			//guardar valor de casos

		}

		print("Quantidade de registros do sensor 1 na Regiao Sul:"+numSul);
	    int temporario = numSul; 
		numSul = 0;
		//guardar valor de casos 

		if(estSensor2 = (int)sensor2A )
		{
			numSul++;
			print("Horario do registro(time stamp) numero " + numSul + "do Sensor 2 na Regiao Sul:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			horarioSul = {horaAtual, minutoAtual, segundoAtual};
			for (int i = 0; i < numSul; ++i) {
				ListadeEventosSul.Add (numSul + temporario);
				ListadeHorariosSul.Add (horarioSul);

			}
		}

		print("Quantidade de registros do sensor 2 na Regiao Sul:"+numSul);
		numSul = temporario + numSul;

		print("Total de registros dos sensores da regiao Sul:" +numSul);
		for(int y = 0; y < numSul; ++y){
			print(ListadeEventosSul[y]);
			print(ListadeHorariosSul[y]);
		}

	
	}

	public Sul()
	{
		this.sensor1Sul;
		this.sensor2Sul;
	}
}



class Nordeste : Brasil
{
	public int sensorNordeste;
	enum STT3 {Registra, Nointerruption}
	List<int> ListadeEventosNordeste = new List<int>();
	List<int> ListadeHorariosNordeste = new List<int>();
	int[] horariosNordeste = new int[3];
	STT3 sensorA = STT3.Registra;
	STT3 sensorB = STT3.Nointerruption;
	int estSensor;
	bool ver3; 

	public bool verificadorNordeste()
	{
		if(estSensor = (int)sensorA)
		{
			ver3 = true;
		}else{
			ver3 = false;
		}
		return ver3;

	}


	public void funcaodonordeste ()
	{
		base.segundoAtual;
		base.minutoAtual;
		base.horaAtual;

		int numNordeste = 0;


		if(estSensor = (int)sensorA )
		{
			numNordeste++;
			print("Quantidade de registros do sensor Nordeste:"+numNordeste);
			print ("Horario do registro" + numNordeste + "do sensor Nordeste:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			horariosNordeste = {horaAtual, minutoAtual, segundoAtual};
			for(i = 0; i < numNordeste; ++i)
			{
				ListadeEventosNordeste.Add(numNordeste);
				ListadeHorariosNordeste.Add(horariosNordeste);

			}
			//guardar valor de casos
			}

		for(int y = 0; y < numNordeste; ++y){
			print(ListadeEventosNordeste[y]);
			print(ListadeHorariosNordeste[y]);
		}

	}

	public Nordeste(){
		this.sensorNordeste;  
}
}



class Norte : Brasil
{
	public int sensorNorte;
	List<int> ListadeHorariosNorte = new List<int>();
	List<int> ListadeEventosNorte = new List<int>();
	int[] horario = new int[3];
	enum STT4 {Registra, Nointerruption}
	STT4 sensorA = STT4.Registra ;
	STT4 sensorB = STT4.Nointerruption ;
	int estSensor;
	bool ver4;

	public bool verificadorNorte()
	{
		if(estSensor = (int)sensorA)
		{ ver4 = true;
		}else{
			ver4 = false;
		}
		return ver4;
	}

	public void funcaodonorte ()
	{
		base.segundoAtual;
		base.minutoAtual;
		base.horaAtual;

		int numNorte = 0;


		if(estSensor = (int)sensorA )
		{
			numNorte++;
			print("Quantidade de registros do sensor Norte:"+numNorte);
			print ("Horario do registro" + numNorte + "do sensor Norte:" + horaAtual + ":" + minutoAtual + ":" + segundoAtual);
			horario = {horaAtual,minutoAtual,segundoAtual}

			for(i = 0; i<numNorte; ++i)
			{
					ListadeHorariosNorte.Add(horario);
					ListadeEventosNorte.Add(numNorte);

			}
			//guardar valor de casos
		}
					

	for(int y = 0; y < numNorte; ++y){
			print(ListadeEventosNorte[y]);
			print(ListadeHorariosNorte[y]);
		}}
	public Norte()
	
		this.sensorNorte;
	}


}
