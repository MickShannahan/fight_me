import Swal from 'sweetalert2'
import 'sweetalert2/dist/sweetalert2.min.css'
import { computed } from "vue"
import { AppState } from "../AppState"
import { logger } from "./Logger"

export default class Pop {
  /**
 *
 * @param {string} title The title text.
 * @param {string} text The body text.
 * @param {string} icon 'success', 'error', 'info', 'warning', or 'question'.
 * @param {string} confirmButtonText The text of your confirm button.
 * -----------------------------------
 * {@link https://sweetalert2.github.io/#configuration|Check out Sweet Alerts}
 */
  static async confirm(title = 'Are you sure?', text = "You won't be able to revert this!", icon = 'warning', confirmButtonText = 'Yes, delete it!') {
    try {
      const res = await Swal.fire({
        title: title,
        text: text,
        icon: icon,
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: confirmButtonText
      })
      if (res.isConfirmed) {
        return true
      }
      return false
    } catch (error) {
      return false
    }
  }

  /**
 *
 * @param {string} title The title text
 * @param {string} display 'success', 'error', 'info', 'warning', or 'question'.
 * @param {string} position 'top', 'top-start', 'top-end', 'center', 'center-start', 'center-end', 'bottom', 'bottom-start', or 'bottom-end'.
 * @param {number} timer Time in milliseconds.
 * @param {boolean} progressBar Show progress bar or not respectively.
 * -----------------------------------
 * {@link https://sweetalert2.github.io/#configuration|Check out Sweet Alerts}
 */
  static toast(title = 'Warning!', display = 'warning', position = 'top-end', timer = 3000, progressBar = true) {
    const theme = AppState.theme
    logger.log(theme)
    Swal.fire({
      title: title,
      icon: display,
      position: position,
      timer: timer,
      timerProgressBar: progressBar,
      toast: true,
      showConfirmButton: false,
      customClass:{
        popup: theme ? 'bg-white': 'bg-secondary' ,
        title: theme ? 'text-dark' : 'text-dark'
      }
    })
  }
  static error(error ={}, position = 'top-end') {
    Swal.fire({
      title: error.response?.data?.error?.message || error.response?.data || error.message,
      icon: 'error',
      position: position,
      timer: 4000,
      timerProgressBar: true,
      toast: true,
      showConfirmButton: false,
      customClass:{
        popup: 'bg-danger lighten-30',
        title: 'text-dark'
      }
    })
  }
}
