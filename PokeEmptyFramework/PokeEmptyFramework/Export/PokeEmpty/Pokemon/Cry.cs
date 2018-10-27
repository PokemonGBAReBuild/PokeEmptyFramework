/*
 * Creado por SharpDevelop.
 * Usuario: PokemonGBAReBuild
 * Fecha: 14/10/2018
 * Hora: 19:57
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using PokemonEmptyFramework;
using System;
using System.IO;
using Frame= PokemonEmptyFramework;
namespace PokemonEmptyFramework.Export.PokeEmpty.Pokemon
{
	/// <summary>
	/// Description of Cry.
	/// </summary>
	public static class Cry
	{
		public static string PathVoiceGroups= Path.Combine("sound","voice_groups.inc");
		public static string PathDirectSoundData= Path.Combine("sound","direct_sound_data.inc");
		public static string PathDirCries= Path.Combine("sound","direct_sound_samples","cries");
		
		public static void SetPath(DirectoryInfo dirProject,Frame.Pokemon pokemon)
		{ 
			pokemon.Cry.Sonido.Path=new FileInfo(Path.Combine(dirProject.FullName,PathDirCries,string.Format("cry_{0}.aif",pokemon.Nombre.Text.ToLower())));
		}
		public static void Save(DirectoryInfo dirProject,Frame.Pokemon pokemon)
		{//por mirar...
			bool encontrado=false;
			string cryLine;
			SetPath(dirProject,pokemon);
			TextFile.GetStringLine(dirProject,PathDirectSoundData,(linea)=>{
			                       	encontrado=linea.Contains(pokemon.Nombre.Text);
			                       	return encontrado;
			                       },0);
			if(!encontrado)
			{//parece que no hay orden... por eso lo pongo depués del primero
				TextFile.SetStringLines(dirProject,PathDirectSoundData,(linea)=>linea.Contains("cry_"),0,(linea)=>true,GetDirectSoundStrings(pokemon),false);
			}
			//mirar como va la parte de VoiceGroups que parece que falten...
			encontrado=false;
			cryLine=GetCryVoiceGroup(pokemon);
			TextFile.GetStringLine(dirProject,PathVoiceGroups,(linea)=>{
			                       	encontrado=linea.Contains(cryLine);
			                       	return encontrado;
			                       },0);
			if(!encontrado)
			{
				//falta saber donde pongo la string cambiar 0
				TextFile.SetStringLine(dirProject,PathDirectSoundData,(linea)=>linea.Contains("gCryTable"),0,cryLine,false);

			}
			encontrado=false;
			cryLine=GetCryVoiceGroup(pokemon,false);
			TextFile.GetStringLine(dirProject,PathVoiceGroups,(linea)=>{
			                       	encontrado=linea.Contains(cryLine);
			                       	return encontrado;
			                       },0);
			if(!encontrado)
			{
				//de momento no se como va porque parece que el orden no está correcto...la parte de src/data/pokemon/cry_ids.h no la entiendo...faltan pokemon...
				//falta saber donde pongo la string cambiar 0
				TextFile.SetStringLine(dirProject,PathDirectSoundData,(linea)=>linea.Contains("gCryTable2"),0,cryLine,false);//por hacer
				
			}
		}
		public static string[] GetDirectSoundStrings(Frame.Pokemon pokemon)
		{
			string[] directSoundStrings=new string[3];
			directSoundStrings[0]="\t.align 2";
			directSoundStrings[1]=String.Format("Cry_{0}::",pokemon.Nombre.Text);
			directSoundStrings[2]=String.Format("\t.incbin \"{0}{1}cry_{2}.bin\"",PathDirectSoundData,Path.DirectorySeparatorChar,pokemon.Nombre.Text.ToLower());
			return directSoundStrings;
		}
		public static string GetCryVoiceGroup(Frame.Pokemon pokemon,bool isTable1=true)
		{
			return string.Format("{0} Cry_{1}",isTable1?"cry":"cry2",pokemon.Nombre.Text);
		}
	}
}
