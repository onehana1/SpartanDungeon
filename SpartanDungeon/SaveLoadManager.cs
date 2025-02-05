using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SpartanDungeon
{
    public class SaveLoadManager
    {
        private static string saveFilePath = Path.Combine(Directory.GetCurrentDirectory(), "playerData.json");


        public static void SavePlayerData(Player player)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,   // 들여쓰기 적용시킴
                    IncludeFields = true,  // 모든 필드를 포함하여 저장
                };

                string json = JsonSerializer.Serialize(player, options);
                File.WriteAllText(saveFilePath, json);
                Console.WriteLine("\n게임 데이터가 저장되었습니다!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장 중 오류 발생: {ex.Message}");
            }
        }

        public static Player LoadPlayerData()
        {
            try
            {
                if (!File.Exists(saveFilePath))
                {
                    Console.WriteLine("\n저장된 데이터가 없습니다.");
                    return null;
                }

                string json = File.ReadAllText(saveFilePath);
                Console.WriteLine("\n저장된 JSON 데이터:\n" + json);  // JSON 데이터 확인

                var options = new JsonSerializerOptions
                {
                    IncludeFields = true
                };

                Player loadedPlayer = JsonSerializer.Deserialize<Player>(json, options);
                if (loadedPlayer != null && loadedPlayer.inventory != null)
                {
                    loadedPlayer.inventory.SetPlayer(loadedPlayer); // inventory의 player 설정
                }

                return loadedPlayer;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"저장된 데이터를 불러오는 중 오류 발생: {ex.Message}");
                return null;
            }
        }
    }


}
