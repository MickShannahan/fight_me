import { AppState } from "../AppState"
import { logger } from "../utils/Logger"
import { api } from "./AxiosService"



class GamesService{

  async getGames(query =''){
    AppState.loading = true
    const res = await api.get('api/games' + query)
    logger.log('get games', res.data)
    AppState.games = res.data
    AppState.loading = false
  }

}

export const gamesService = new GamesService()
