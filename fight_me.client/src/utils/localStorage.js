import { AppState } from "../AppState"
import { logger } from "./Logger"


class LocalStorage{
  savePrefs(update){
    let saveData = JSON.parse(localStorage.getItem('FM-Prefrences'))
    if(saveData == null) saveData = {}
    saveData = {...saveData, ...update}
    logger.log('saving', saveData)
    localStorage.setItem('FM-Prefrences', JSON.stringify(saveData))
  }

  loadPrefs(){
    let data = JSON.parse(localStorage.getItem('FM-Prefrences'))
    logger.log('loading', data)
    if(data){
      for(let key in data){
        AppState[key] = data[key]
      }
    }
  }
}

export const localStore = new LocalStorage()
