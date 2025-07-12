
using UnityEngine;
namespace Npc
{
    [CreateAssetMenu(fileName = "AiBehaviour", menuName = "NPC/AiBehaviour", order = 1)]
    public class AiBehaviour : ScriptableObject
    {

        /*
         * A IA dos npcs ser� baseada em estados, e cada estado mudar� de acordo com o tempo atual do dia. Os dias
         * ser�o guiados por hora e minutos.
            Npc ter� alguns comportamentos, como:
            - Idle: Ficar parado, olhando para o nada, trocando a anima��o dele de tempos em tempos.
            - Roam: o npc ter� rotas pr�-definidas, e ir� andar por ela. Ao chegar no final de uma cena
            e ainda n�o ter terminado sua rota, ele ser� teleportado para outra cena, onde continuar� sua rota.
            - Follow: o npc ir� seguir o player, mas n�o ir� atacar ele. Ele ir� apenas seguir o player.
            - GoSleep: o npc ir� dormir, e acordar� ap�s um tempo. Ele ir� trocar a anima��o dele de tempos em tempos.

         */
    }
}