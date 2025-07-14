namespace Npc
{
    /*
        A IA dos npcs será baseada em estados, e cada estado mudará de acordo com o tempo atual do dia. Os dias
        serão guiados por hora e minutos.
        Npc terá alguns comportamentos, como:
        - Idle: Ficar parado, olhando para o nada, trocando a animação dele de tempos em tempos.
        - Roam: o npc terá rotas pré-definidas, e irá andar por ela. Ao chegar no final de uma cena
        e ainda não ter terminado sua rota, ele será teleportado para outra cena, onde continuará sua rota.
        - Follow: o npc irá seguir o player, mas não irá atacar ele. Ele irá apenas seguir o player.
        - GoSleep: o npc irá dormir, e acordará após um tempo. Ele irá trocar a animação dele de tempos em tempos.
        
    */

    public enum NpcState 
    {
        Idle,
        Roam,
        Follow,
        GoSleep
    }
}