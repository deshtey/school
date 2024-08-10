import 'src/global.css';

// ----------------------------------------------------------------------

import { CONFIG } from 'src/config-global';
import { primary } from 'src/theme/core/palette';
import { ThemeProvider } from 'src/theme/theme-provider';
import { getInitColorSchemeScript } from 'src/theme/color-scheme-script';

import { ProgressBar } from 'src/components/progress-bar';
import { MotionLazy } from 'src/components/animate/motion-lazy';
import { detectSettings } from 'src/components/settings/server';
import { SettingsDrawer, defaultSettings, SettingsProvider } from 'src/components/settings';

import { AuthProvider } from 'src/auth/context/jwt';
import { ReduxProvider } from 'src/lib/ReduxProvider';
import { I18NProvider } from 'next/dist/server/future/helpers/i18n-provider';
import { I18nProvider, LocalizationProvider } from 'src/locales';
import { detectLanguage } from 'src/locales/server';

// ----------------------------------------------------------------------

export const viewport = {
  width: 'device-width',
  initialScale: 1,
  themeColor: primary.main,
};

export default async function RootLayout({ children }) {
  const lang = CONFIG.isStaticExport ? 'en' : await detectLanguage();

  const settings = CONFIG.isStaticExport ? defaultSettings : await detectSettings();
  return (
    <html lang={lang ?? 'en'} suppressHydrationWarning>
      <body>
        {getInitColorSchemeScript}
        <ReduxProvider>
          <I18nProvider lang={CONFIG.isStaticExport ? undefined : lang}>
            <LocalizationProvider>
              <AuthProvider>
                <SettingsProvider
                  settings={settings}
                  caches={CONFIG.isStaticExport ? 'localStorage' : 'cookie'}
                >
                  <ThemeProvider>
                    <MotionLazy>
                      <ProgressBar />
                      <SettingsDrawer />
                      {children}
                    </MotionLazy>
                  </ThemeProvider>
                </SettingsProvider>
              </AuthProvider>
            </LocalizationProvider>
          </I18nProvider>
        </ReduxProvider>
      </body>
    </html>
  );
}
