import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  loading: false,
  theme: false,
  user: {},
  account: {},
  accountLeagues: {},
  games: [],
  activeGame: {},
  categories: {},
  searchCategories: []
})
