//
//  DemoInitializationDelegate.swift
//  IronSourceSwiftDemoApp
//
//  Copyright © 2024 ironSource Mobile Ltd. All rights reserved.
//

import Foundation
import IronSource

class DemoInitializationDelegate: NSObject, ISInitializationDelegate {
    
    weak var delegate: DemoViewControllerDelegate?

    init(delegate: DemoViewControllerDelegate!) {
        self.delegate = delegate
    }
    
    /**
     Called after the Mediation successfully completes its initialization
     */
    func initializationDidComplete() {
        print("DemoInitializationDelegate \(#function)")
        
        self.delegate?.setButtonEnablement(ButtonIdentifiers.loadInterstitialButtonIdentifier, enable: true)
        self.delegate?.setButtonEnablement(ButtonIdentifiers.loadBannerButtonIdentifier, enable: true)
    }
}

