import i18n, { changeLanguage } from "i18next";
import { initReactI18next, useTranslation } from "react-i18next";
import enTranslations from './translations/en.json'
import uaTranslations from './translations/ua.json'
import e from "express";

export const setupLocalization = () => {
    i18n
    .use(initReactI18next) // passes i18n down to react-i18next
    .init({
      // the translations
      // (tip move them in a JSON file and import them,
      // or even better, manage them via a UI: https://react.i18next.com/guides/multiple-translation-files#manage-your-translations-with-a-management-gui)
      resources: {
        en: {
          translation: enTranslations
        },
        ua: {
          translation: uaTranslations
        }
      },
      lng: getLanguageFromLocalStorage(), // if you're using a language detector, do not define the lng option
      fallbackLng: "en",
  
      interpolation: {
        escapeValue: false // react already safes from xss => https://www.i18next.com/translation-function/interpolation#unescape
      }
    });
}

const localStoragePath = "language";

export const changeLanguageWithLocalStorage = (language: 'ua' | 'en') => {
  changeLanguage(language)

  localStorage.setItem(localStoragePath, language);

}

const getLanguageFromLocalStorage = () => {
  return localStorage.getItem(localStoragePath) ?? "en";
}