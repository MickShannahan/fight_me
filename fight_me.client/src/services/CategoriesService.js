import { AppState } from "../AppState";
import { logger } from "../utils/Logger";
import { api } from "./AxiosService";


class CategoriesService{

  async getCategories(query = '', id = 'all'){
    AppState.loading = true
    const res = await api.get('api/data/categories'+ query)
    logger.log(res.data)
    AppState.categories[id] = res.data
    AppState.loading = false
  }
}

export const categoriesService = new CategoriesService();
