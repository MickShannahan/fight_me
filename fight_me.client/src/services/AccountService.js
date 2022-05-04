import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getAccountLeagues(){
    const res = await api.get('/account/leagues')
    logger.log('account leagues', res.data)
    res.data.forEach(l => AppState.accountLeagues[l.id] = l)
  }
}

export const accountService = new AccountService()
